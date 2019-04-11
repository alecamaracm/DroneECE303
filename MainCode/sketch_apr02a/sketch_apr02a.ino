#include <driver/adc.h>

#include "pinDefinitions.cpp"
#include "PIDconstants.cpp"

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <Adafruit_BME280.h>

#include <VL53L0X.h>

#define SEALEVELPRESSURE_HPA (1013.25)
#define MAX_PITCHROLL_GOAL 25


//Serial
String serialContents,msgID,msgLen,msgData;
char outputSerial[200];

//PWM output stuff
int PWM_freq=50;
int pwmData[16];
bool motorEnabled[4];
bool newPWMDataToOutput=false;
int lastMotorPowers[4];
hw_timer_t * PWMtimer = NULL;

//IR positioning stuff
byte IRdata_buf[16];
int IRx[4];
int IRy[4];
int IRbuff;
int IRv1[4]; //X1,Y1,X2,Y2
bool IRDataFine=true;
int IrTLeft,IrTRight,IrTBack,IrTMiddle;

//FPS
int FPSgoal=100;
long startMicro=0; //When the loop started
long timeTaken=0;  //Time taken to complete a loop
int cycleCounter=0; //At 1.000.000, reset

int lastSecondMillis=0;
int FPScounter=0;

//BME280
Adafruit_BME280 bme;
float temperature,humidity,baromPressure;

//IMU
Adafruit_BNO055 bno = Adafruit_BNO055();
uint8_t sysCal, gyroCal, accelCal, magCal = 0;
float imuX,imuY,imuZ;  //X is yaw. Y is roll and Z is pitch
float lastImuX,lastImuY,lastImuZ;
float imuCalX,imuCalY,imuCalZ;
float imuXspeed,imuYspeed,imuZspeed;
float imuErrorX,imuErrorY,imuErrorZ;
float imuCalcPitch,imuCalcRoll,imuCalcYaw;
float imuCalcM1,imuCalcM2,imuCalcM3,imuCalcM4;

//Controls
float XBOXthrottleGoal=0;
float XBOXpitchGoal,XBOXrollGoal,XBOXyawGoal;




//VL53LOX
VL53L0X sensor;
float TOFAltitude;



void setup() {
Serial.begin(115200);
 Serial2.begin(38400,SERIAL_8N1,25,26);

serialContents.reserve(150);
msgID.reserve(25);
msgLen.reserve(25);
msgData.reserve(150);

  startPWM();   
  pinMode(PIN_BUZZER,OUTPUT);

  initializeSensors(); 
  

  

  digitalWrite(PIN_BUZZER,HIGH);
  delay(2500);
  digitalWrite(PIN_BUZZER,LOW);
}

void initializeSensors()
{
  initializeIRSensor();
   /* Initialise the sensor */
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial2.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while(1);
  }
  if (!bme.begin()) {
      Serial2.println("Could not find a valid BME280 sensor, check wiring!");
      while (1);
  }
  
  Wire.begin(14,27);
  sensor.init();
  sensor.setTimeout(500);

  sensor.setSignalRateLimit(0.1);
  // increase laser pulse periods (defaults are 14 and 10 PCLKs)
  sensor.setVcselPulsePeriod(VL53L0X::VcselPeriodPreRange, 18);
  sensor.setVcselPulsePeriod(VL53L0X::VcselPeriodFinalRange, 14);

  delay(2000);
  bno.setExtCrystalUse(true);
  delay(1000);
  
  readIMUValues();
  imuCalibrate();
}


void loop() {

  startMicro=micros();

  readIMUValues();
  if(cycleCounter%(FPSgoal/2)==10)readBME280Values();

  if(Serial2.available()>0)
  {
    serialContents = Serial2.readStringUntil('@');
    parseSerialData();
  }


  updateRawIRData();
  processIRData();
  
  if(cycleCounter%(FPSgoal/3)==0)
  {
      printIRPoints();
    printIRData();
  }

  if(cycleCounter%(FPSgoal/2)==5)
  {
    SendVolts();
  }

  if(cycleCounter%(FPSgoal/5)==1)
  {
    SendCurrentMotorPower();
  }

  if(cycleCounter%(FPSgoal/5)==8)
  {
    sendIMUData();
  }

   if(cycleCounter%(FPSgoal/2)==3)
  {
    sendCurrentData();
  }


  doPIDWork();
  
  

  cycleCounter++;
  if(cycleCounter>1000000) cycleCounter=0;

  timeTaken=micros()-startMicro; 
  if(timeTaken<(1000000/FPSgoal) && timeTaken>0) delayMicroseconds((1000000/FPSgoal)-timeTaken);
  
  if(lastSecondMillis/1000!=millis()/1000)  //We are in a different second, send the FPS
  {
    sprintf(outputSerial,"%d",FPScounter+1);
    sendOutputMessage("FPS");    
    FPScounter=0;
    lastSecondMillis=millis();
  }else
  {
    FPScounter++;
  }

  
}

void sendIMUData()
{
  sprintf(outputSerial,"%d|%d|%d",(int)(imuZ*100),(int)(imuY*100),(int)(imuX*100));
  sendOutputMessage("IMUDATA");
}

void imuCalibrate()
{
  imuCalX=imuX;
  imuCalY=imuY;
  imuCalZ=imuZ;
}

void doPIDWork()
{
    imuErrorX=imuX-XBOXyawGoal;
    imuErrorY=imuY-XBOXrollGoal;
    imuErrorZ=imuZ-XBOXpitchGoal;
    
    imuCalcPitch=constrain(XBOX_KP*imuErrorZ-XBOX_KD*imuZspeed+XBOX_KI*0,-XBOX_PITCH_MAX_CHANGE,XBOX_PITCH_MAX_CHANGE);
    imuCalcRoll=constrain(XBOX_KP*imuErrorY-XBOX_KD*imuYspeed+XBOX_KI*0,-XBOX_ROLL_MAX_CHANGE,XBOX_ROLL_MAX_CHANGE);
  //  imuCalcYaw=constrain(XBOX_KP_YAW*imuErrorX+XBOX_KD_YAW*imuXspeed+XBOX_KD_YAW*0,-XBOX_YAW_MAX_CHANGE,XBOX_YAW_MAX_CHANGE);

    imuCalcM1=XBOXthrottleGoal-imuCalcPitch-imuCalcRoll+imuCalcYaw;
    imuCalcM2=XBOXthrottleGoal+imuCalcPitch-imuCalcRoll-imuCalcYaw;
    imuCalcM3=XBOXthrottleGoal-imuCalcPitch+imuCalcRoll-imuCalcYaw;
    imuCalcM4=XBOXthrottleGoal+imuCalcPitch+imuCalcRoll+imuCalcYaw;

    constrain(imuCalcM1,0,100);
    constrain(imuCalcM2,0,100);
    constrain(imuCalcM3,0,100);
    constrain(imuCalcM4,0,100);

    setMotorPower(0,imuCalcM1,false);
    setMotorPower(1,imuCalcM2,false);
    setMotorPower(2,imuCalcM3,false);
    setMotorPower(3,imuCalcM4,true);
        
 /*   Serial.println();
    Serial.println(imuX);
    Serial.println(imuY);
    Serial.println(imuZ);
    delay(1000);*/
}

void SendVolts()
{    
    int read_raw;
    adc2_config_channel_atten( ADC2_CHANNEL_0, ADC_ATTEN_11db );

    esp_err_t r = adc2_get_raw( ADC2_CHANNEL_0, ADC_WIDTH_12Bit, &read_raw);
    if ( r == ESP_OK ) {
        sprintf(outputSerial,"%d",read_raw);
        sendOutputMessage("MAINVOLTS");
    }    
}

int adcAmp1,adcAmp2,adcAmp3,adcAmp4,adcAmp5V;

void sendCurrentData()
{
  adc1_config_channel_atten( PIN_AMP_M1, ADC_ATTEN_11db );
  adc1_config_channel_atten( PIN_AMP_M2, ADC_ATTEN_11db );
  adc1_config_channel_atten( PIN_AMP_M3, ADC_ATTEN_11db );
  adc1_config_channel_atten( PIN_AMP_M4, ADC_ATTEN_11db );
  adc2_config_channel_atten( PIN_AMP_5V, ADC_ATTEN_11db );

  adc2_get_raw( PIN_AMP_5V, ADC_WIDTH_12Bit, &adcAmp5V);
  adcAmp1=adc1_get_raw(PIN_AMP_M1);
  adcAmp2=adc1_get_raw(PIN_AMP_M2);
  adcAmp3=adc1_get_raw(PIN_AMP_M3);
  adcAmp4=adc1_get_raw(PIN_AMP_M4);

  sprintf(outputSerial,"%d|%d|%d|%d|%d",adcAmp5V,adcAmp1,adcAmp2,adcAmp3,adcAmp4);
  sendOutputMessage("AMPS");

}

void sendOutputMessage(char *key)
{
  Serial2.print(key);
  Serial2.print("|");
  Serial2.print(strlen(outputSerial)+strlen(key));
  Serial2.print("|");
  Serial2.print(outputSerial);
  Serial2.print("O_o");
  memset(outputSerial, 0, 200);
}

void SendCurrentMotorPower()
{  
  sprintf(outputSerial,"%d|%d|%d|%d",lastMotorPowers[0],lastMotorPowers[1],lastMotorPowers[2],lastMotorPowers[3]);
  sendOutputMessage("MPOWS");
}

float pitchToWrite,rollToWrite,yawToWrite=0;
int temp1,temp2,temp3;
void parseSerialData()
{
    temp1=serialContents.indexOf("|");
    temp2=serialContents.indexOf("|",temp1+1);
    
  msgID=serialContents.substring(0,temp1);
  msgLen=serialContents.substring(temp1+1,temp2);
  msgData=serialContents.substring(temp2+1);

  if(msgData.length()+msgID.length()!=msgLen.toInt())
{
  sprintf(outputSerial,"");
  sendOutputMessage("SERIALERR");
  return;
}
  
  if(msgID=="MANPWR")
  {
    XBOXthrottleGoal=msgData.toInt()/10;
      /*setMotorPower(0,msgData.toInt()/10,false); //Receives a number between 1000 and 0
      setMotorPower(1,msgData.toInt()/10,false);
      setMotorPower(2,msgData.toInt()/10,false);
      setMotorPower(3,msgData.toInt()/10,true);  */    
  }else if(msgID=="MOTOREN")
  {
      int motorID=msgData.substring(0,1).toInt();
      if(motorID<0||motorID>3) return;
      if(msgData.substring(1)=="on") //Enable motor
      {
        motorEnabled[motorID]=true;
      }else //Disable motor
      {
        motorEnabled[motorID]=false;
      }

      setMotorPower(motorID,-1,true); //We send a power of -1 to avoid overriding it, we only want the method to update the pwm based on the motor being enabled or not      
  }else if(msgID=="FPSGOAL")
  {   
       int newGoal=msgData.toInt();
       if(newGoal>0) FPSgoal=newGoal;       
  }else if(msgID=="CDATA")
  {
    temp1=msgData.indexOf("|");
    temp2=msgData.indexOf("|",temp1+1);
    
    pitchToWrite=msgData.substring(0,temp1).toInt()/100.0f;
    rollToWrite=msgData.substring(temp1+1,temp2).toInt()/100.0f;
    yawToWrite=msgData.substring(temp2+1).toInt()/100.0f;

    if(pitchToWrite>-MAX_PITCHROLL_GOAL && pitchToWrite<MAX_PITCHROLL_GOAL) XBOXpitchGoal=pitchToWrite;
    if(rollToWrite>-MAX_PITCHROLL_GOAL && rollToWrite<MAX_PITCHROLL_GOAL) XBOXrollGoal=rollToWrite;
    XBOXyawGoal=yawToWrite;
  }
}


void readTOFValues()
{
  TOFAltitude=sensor.readRangeSingleMillimeters();
}

void readIMUValues()
{  
  sensors_event_t event;
  bno.getEvent(&event);

  
  lastImuX=imuX;
  lastImuY=imuY;
  lastImuZ=imuZ;
  imuX=(float)event.orientation.x-imuCalX;
  imuY=(float)event.orientation.y-imuCalY;
  imuZ=(float)event.orientation.z-imuCalZ;
  imuXspeed=imuX-lastImuX;
  imuYspeed=imuY-lastImuY;
  imuZspeed=imuZ-lastImuZ;
  
  bno.getCalibration(&sysCal, &gyroCal, &accelCal, &magCal);

  
}

void readBME280Values()
{
   temperature=bme.readTemperature();  //degrees C 
   baromPressure=(bme.readPressure() / 100.0F); //hPa
   humidity=bme.readHumidity(); //%
}

void setMotorPower(int motorID,float power,bool sendUpdate)
{
  if(motorID>3) return;
  
  if(motorEnabled[motorID]==true)
  {
    if(power==-1)power=lastMotorPowers[motorID]; //power of -1 means no change
    if(power>100)power=100;
    if(power<0)power=0;
    pwmData[motorID]=4096-(205+((power/100)*205));
    lastMotorPowers[motorID]=(int)power;
  }else
  {
    pwmData[motorID]=4096-205;
    lastMotorPowers[motorID]=0;
  }
  
  //pwmData[motorID]=(power/100)*4095;
  
  if(sendUpdate)
  {
    sendPWMData();
  }
}


void startPWM()
{
  for(int i=0;i<4;i++) motorEnabled[i]=false;
  
  PWMtimer = timerBegin(1, 10, true);  //8,000,000
  timerAttachInterrupt(PWMtimer, &onPWMTimer, true);
  timerAlarmWrite(PWMtimer, 8000000/PWM_freq, true);
  timerAlarmEnable(PWMtimer);

  ledcSetup(0, PWM_freq*4096, 1); //This sets up the main clock for the PWM IC (TCL5940)
  ledcWrite(0,1);
  ledcAttachPin(PIN_PWM_GSCLK, 0);

  for(int i=0;i<16;i++)  pwmData[i]=4096-(205);


  pinMode(PIN_PWM_BLANK,OUTPUT);
  pinMode(PIN_PWM_SCLK,OUTPUT);
  pinMode(PIN_PWM_LATCH,OUTPUT);
  pinMode(PIN_PWM_SIN,OUTPUT);
  pinMode(PIN_PWM_BLANK,OUTPUT);
  
  digitalWrite(PIN_PWM_BLANK,HIGH); //HIGH means off
  digitalWrite(PIN_PWM_SCLK,LOW);
  digitalWrite(PIN_PWM_LATCH,LOW);  //HIGH pulse of at least 20ns after sending the data to activate it 
  digitalWrite(PIN_PWM_SIN,LOW);

  newPWMDataToOutput=true;
}

void onPWMTimer()
{
  digitalWrite(PIN_PWM_BLANK,HIGH); //Stops the PWM outputs
  if(newPWMDataToOutput)
  {
    digitalWrite(PIN_PWM_LATCH,HIGH);
    digitalWrite(PIN_PWM_LATCH,LOW);
    newPWMDataToOutput=false;
  } 
  digitalWrite(PIN_PWM_BLANK,LOW);
}

void sendPWMData()
{
   for(int i=15;i>=0;i--) shift12BitsOut(PIN_PWM_SIN,PIN_PWM_SCLK, pwmData[i]);
   newPWMDataToOutput=true;
}

void shift12BitsOut(uint8_t dataPin, uint8_t clockPin, int val) {
    for(uint8_t i = 0; i < 12; i++) {
        digitalWrite(dataPin, !!(val & (1 << (11 - i))));
        digitalWrite(clockPin, HIGH);
        digitalWrite(clockPin, LOW);  
    }
}



void initializeIRSensor()
{
  Wire.begin(14,27);
    // IR sensor initialize
    Write_2IRbytes(0x30,0x01); delay(10);
    Write_2IRbytes(0x30,0x08); delay(10);
    Write_2IRbytes(0x06,0x90); delay(10);
    Write_2IRbytes(0x08,0xC0); delay(10);
    Write_2IRbytes(0x1A,0x40); delay(10);
    Write_2IRbytes(0x33,0x33); delay(10);
    delay(100);
}

void updateRawIRData()
{
    Wire.beginTransmission(0x58);
    Wire.write(0x36);
    Wire.endTransmission();

    Wire.requestFrom(0x58, 16);        // Request the 2 byte heading (MSB comes first)
    for (int i=0;i<16;i++) { IRdata_buf[i]=0; }
    int i=0;
    while(Wire.available() && i < 16) { 
        IRdata_buf[i] = Wire.read();
        i++;
    }

    for(int i=0;i<4;i++)
    {
      IRx[i] = IRdata_buf[i*3+1];
      IRy[i] = IRdata_buf[i*3+2];
      IRbuff   = IRdata_buf[i*3+3];
      IRx[i] += (IRbuff & 0x30) <<4;
      IRy[i] += (IRbuff & 0xC0) <<2;
    }
}

void processIRData()
{    
    IRDataFine=true;
    IrTLeft=-1;
    IrTRight=-1;
    IrTBack=-1;
    IrTMiddle=-1;
  
    for(int i=0;i<4;i++)
    {
      if(IRx[i]==1023 || IRy[i]==1023)
      {
        IRDataFine=false;
    //    Serial.println("Not enough points!");
        return;
      }      
    }

    for(int i=0;i<4;i++)
    {
       for(int j=0;j<4;j++)
      {
        if(i>j)
        {
          int midPointX=(IRx[i]+IRx[j])/2;
          int midPointY=(IRy[i]+IRy[j])/2;

          for(int k=0;k<4;k++)
          {
            if(k!=i && k!=j)
            {
              if(sqrt(pow(midPointX-IRx[k],2)+pow(midPointY-IRy[k],2))<10)
              {
                IrTLeft=i;  //We don't know if they are left or right side of the T, we will change that later on
                IrTRight=j;
                IrTMiddle=k;
              }
            }
          }
        }
      }
    }

    if(IrTLeft==-1 || IrTRight==-1 || IrTMiddle==-1)
    {
   //   Serial.println("Not found!");
      return;
    }

    for(int i=0;i<4;i++) if(i!=IrTLeft && i!=IrTRight && i!=IrTMiddle) IrTBack=i;   //Set the back light id (The only left)

    float backToMiddleX=IRx[IrTMiddle]-IRx[IrTBack];
    float backToMiddleY=IRy[IrTMiddle]-IRy[IrTBack];
   

    float dist=(IRx[IrTLeft]-IRx[IrTBack])*(backToMiddleY)-(IRy[IrTLeft]-IRy[IrTBack])*(backToMiddleX);

    if(dist<0)
    {
      int temp=IrTRight;
      IrTRight=IrTLeft;
      IrTLeft=temp;
    }
    
  //  Serial.println("Found!");
    
}

int getAngle(int x1,int y1,int x2, int y2)
{
  int dotPro=x1*x2+y1*y2;
  float mags=sqrt(pow(x1,2)+pow(y1,2))*sqrt(pow(x2,2)+pow(y2,2));
  
  
  return (int)(acos(dotPro/mags)*58.252427f);
}

void printIRData()
{
  sprintf(outputSerial,"%d|%d|%d|%d",IrTLeft,IrTRight,IrTMiddle,IrTBack);
  sendOutputMessage("POINTSDT");
}

void printIRPoints()
{      
    sprintf(outputSerial,"%d|%d|%d|%d|%d|%d|%d|%d",IRx[0],IRy[0],IRx[1],IRy[1],IRx[2],IRy[2],IRx[3],IRy[3]);
    sendOutputMessage("POINTS");  
}

void Write_2IRbytes(byte d1, byte d2)
{
    Wire.beginTransmission(0x58);
    Wire.write(d1); Wire.write(d2);
    Wire.endTransmission();
}
