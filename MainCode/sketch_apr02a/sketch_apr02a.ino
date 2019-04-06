#include <Wire.h>
#define PIN_BUZZER 4

boolean ledState = false;
byte data_buf[16];


int IRx[4];
int IRy[4];
int IRbuff;

int IRv1[4]; //X1,Y1,X2,Y2
bool IRDataFine=true;

int IrTLeft,IrTRight,IrTBack,IrTMiddle;


void setup() {
Serial.begin(115200);

  //  initializeIRSensor();

  pinMode(PIN_BUZZER,OUTPUT);
}

void loop() {
  Serial.println("hi");
  
/*  updateRawIRData();
  processIRData();
  printIRPoints();
  printIRData();*/

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

