#include <Adafruit_BNO055.h>
#include <SimpleKalmanFilter.h>

#define KALMAN_K1 1
#define KALMAN_K2 1
#define KALMAN_K3 0.01

SimpleKalmanFilter kalmanGyroX = SimpleKalmanFilter(KALMAN_K1, KALMAN_K2, KALMAN_K3);
SimpleKalmanFilter kalmanGyroY = SimpleKalmanFilter(KALMAN_K1, KALMAN_K2, KALMAN_K3);

SimpleKalmanFilter kalmanAccelX = SimpleKalmanFilter(KALMAN_K1, KALMAN_K2, KALMAN_K3);
SimpleKalmanFilter kalmanAccelY = SimpleKalmanFilter(KALMAN_K1, KALMAN_K2, KALMAN_K3);
SimpleKalmanFilter kalmanAccelZ = SimpleKalmanFilter(KALMAN_K1, KALMAN_K2, KALMAN_K3);

Adafruit_BNO055 bno = Adafruit_BNO055();
imu::Vector<3> gyro;
imu::Vector<3> accel;


float accX,accY,accZ;
float gyroX,gyroY;
float gyroDT;
long lastGyroMicros=0;

float totalPitch,totalRoll;
float accelPitch,accelRoll;
float accelPitchCal,accelRollCal;



void setup() {

  Serial.begin(115200);
  // put your setup code here,   to run once:
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial2.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while(1);
  }
  
  delay(2000);
  bno.setExtCrystalUse(true);
  delay(1000);
  calibrateIMU();
}

void calibrateIMU()
{
   long startMills=millis();
   while(millis()-startMills<1000)
   {
    getIMUData();
   }
  accelPitchCal=accelPitch;
  accelRollCal=accelRoll;
   
}

void getIMUData()
{
  accel = bno.getVector(Adafruit_BNO055::VECTOR_ACCELEROMETER);
  accX=kalmanAccelX.updateEstimate(accel.x());
  accY=kalmanAccelY.updateEstimate(accel.y());
  accZ=kalmanAccelZ.updateEstimate(accel.z());

  gyroDT=(micros()-lastGyroMicros)/1000000.0f;
  gyro = bno.getVector(Adafruit_BNO055::VECTOR_GYROSCOPE);
  gyroX=kalmanGyroX.updateEstimate(gyro.x());
  gyroY=kalmanGyroY.updateEstimate(gyro.y());
  lastGyroMicros=micros();

  totalRoll+=gyroX*gyroDT;
  totalPitch+=gyroY*gyroDT;  

  accelPitch=(atan(accY/sqrt(pow(accX,2) + pow(accZ,2)))*57.29f) -accelPitchCal;
  accelRoll=(atan(-1*(accX)/sqrt(pow((accY),2) + pow((accZ),2)))*57.29f) - accelRollCal;

  totalRoll=totalRoll*0.97f+accelRoll*0.03f;
  totalPitch=totalPitch*0.97f+accelPitch*0.03f;
  
}

void loop() {
  
   getIMUData(); 
   
  Serial.print(totalPitch);
  Serial.print(" ");
  Serial.println(totalRoll);
  


}
