#include "pinDefinitions.cpp"

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <Adafruit_BME280.h>

#include <VL53L0X.h>
//#include "Adafruit_VL53L0X.h"

//Adafruit_VL53L0X lox = Adafruit_VL53L0X();

int PWM_freq=50;

boolean ledState = false; 
byte data_buf[16];

int pwmData[16];

int IRx[4];
int IRy[4];
int IRbuff;

int IRv1[4]; //X1,Y1,X2,Y2
bool IRDataFine=true;

bool newPWMDataToOutput=false;

#define SEALEVELPRESSURE_HPA (1013.25)

int IrTLeft,IrTRight,IrTBack,IrTMiddle;

hw_timer_t * PWMtimer = NULL;

Adafruit_BME280 bme;
Adafruit_BNO055 bno = Adafruit_BNO055();


VL53L0X sensor;

void setup() {
Serial.begin(115200);

  //  initializeIRSensor();
  startPWM();   
  pinMode(PIN_BUZZER,OUTPUT);

  /* Initialise the sensor */
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while(1);
  }
  if (!bme.begin()) {
      Serial.println("Could not find a valid BME280 sensor, check wiring!");
      while (1);
  }

/*  if (!lox.begin()) {
    Serial.println(F("Failed to boot VL53L0X"));
    while(1);
  }*/

    Wire.begin(14,27);

  sensor.init();
  sensor.setTimeout(500);

sensor.setSignalRateLimit(0.1);
  // increase laser pulse periods (defaults are 14 and 10 PCLKs)
  sensor.setVcselPulsePeriod(VL53L0X::VcselPeriodPreRange, 18);
  sensor.setVcselPulsePeriod(VL53L0X::VcselPeriodFinalRange, 14);
  

  delay(3000);


  bno.setExtCrystalUse(true);


}

void loop() {


  if(Serial.available()>0)
  {
    int pwr=Serial.parseInt();
    setMotorPower(1,pwr,true);    
    setMotorPower(2,pwr,true);    
    setMotorPower(3,pwr,true);    
    setMotorPower(4,pwr,true);    
    Serial.print("Setting power to: ");
    Serial.println(pwr);
  }

  
  Serial.println("Calibration status values: 0=uncalibrated, 3=fully calibrated");
  uint8_t system, gyro, accel, mag = 0;
  bno.getCalibration(&system, &gyro, &accel, &mag);
  Serial.print("CALIBRATION: Sys=");
  Serial.print(system, DEC);
  Serial.print(" Gyro=");
  Serial.print(gyro, DEC);
  Serial.print(" Accel=");
  Serial.print(accel, DEC);
  Serial.print(" Mag=");
  Serial.println(mag, DEC);

  delay(1000);



  Serial.print("Temperature = ");
    Serial.print(bme.readTemperature());
    Serial.println(" *C");

    Serial.print("Pressure = ");

    Serial.print(bme.readPressure() / 100.0F);
    Serial.println(" hPa");

    Serial.print("Approx. Altitude = ");
    Serial.print(bme.readAltitude(SEALEVELPRESSURE_HPA));
    Serial.println(" m");

    Serial.print("Humidity = ");
    Serial.print(bme.readHumidity());
    Serial.println(" %");

    Serial.println();

  /* Display the current temperature */
  int8_t temp = bno.getTemp();
  Serial.print("Current Temperature: ");
  Serial.print(temp);
  Serial.println(" C");
  Serial.println("");

  /*VL53L0X_RangingMeasurementData_t measure;
    
  Serial.print("Reading a measurement... ");
  lox.rangingTest(&measure, false); // pass in 'true' to get debug data printout!

  if (measure.RangeStatus != 4) {  // phase failures have incorrect data
    Serial.print("Distance (mm): "); Serial.println(measure.RangeMilliMeter);
  } else {
    Serial.println(" out of range ");
  }*/
 Serial.print(sensor.readRangeSingleMillimeters());
  if (sensor.timeoutOccurred()) { Serial.print(" TIMEOUT"); }

  Serial.println();
/*  updateRawIRData();
  processIRData();
  printIRPoints();
  printIRData();*/
}

void setMotorPower(int motorID,float power,bool sendUpdate)
{
  if(motorID>15) return;
  
  pwmData[motorID-1]=4096-(205+((power/100)*205));
  //pwmData[motorID]=(power/100)*4095;
  
  if(sendUpdate)
  {
    sendPWMData();
  }
}


void startPWM()
{
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
  Wire.begin();
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
    for (int i=0;i<16;i++) { data_buf[i]=0; }
    int i=0;
    while(Wire.available() && i < 16) { 
        data_buf[i] = Wire.read();
        i++;
    }

    for(int i=0;i<4;i++)
    {
      IRx[i] = data_buf[i*3+1];
      IRy[i] = data_buf[i*3+2];
      IRbuff   = data_buf[i*3+3];
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
  Serial.print("POINTSDT@");
  Serial.print(IrTLeft);
  Serial.print(",");
  Serial.print(IrTRight);
  Serial.print(",");
  Serial.print(IrTMiddle);
  Serial.print(",");
  Serial.print(IrTBack);
  Serial.print("|");
}

void printIRPoints()
{      
    Serial.print("POINTS@");
    for(int i=0; i<4; i++)
    {      
      Serial.print( int(IRx[i]) );
      Serial.print(",");
      Serial.print( int(IRy[i]) );
      if (i<3)
        Serial.print(",");
    }
    Serial.print("|");
    delay(100);
}

void Write_2IRbytes(byte d1, byte d2)
{
    Wire.beginTransmission(0x58);
    Wire.write(d1); Wire.write(d2);
    Wire.endTransmission();
}

