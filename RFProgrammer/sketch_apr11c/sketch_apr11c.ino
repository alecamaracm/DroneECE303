

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial2.begin(115200,SERIAL_8N1,25,26);
}

void loop() {
  // put your main code here, to run repeatedly:
    while (Serial2.available()>0) {        // If HC-12 has data
    Serial.write(Serial2.read());      // Send the data to Serial monitor
  }
  while (Serial.available()>0) {      // If Serial monitor has data
    Serial2.write(Serial.read());      // Send that data to HC-12
  }
}
