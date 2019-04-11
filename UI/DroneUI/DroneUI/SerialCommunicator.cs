using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneUI
{
    public class SerialCommunicator
    {
        Thread receiveThread;
        Thread speedThread;

        Dictionary<string, Action<string, string[]>> handlers = new Dictionary<string, Action<string, string[]>>();

        SerialPort port;
        private Action<string, string> logMethod;
        private Action<string> logGeneral;

        public long downloadSpeed, uploadSpeed;
        public long bytesThisTimeUp, bytesThisTimeDown;

        public long errorsSerialPC, errorsSerialDrone;
        public long errorsSerialPCSec=-1, errorsSerialDroneSec=-1;

        public SerialCommunicator(Action<string,string> logEverything,Action<string> gneralLog)
        {
            logGeneral = gneralLog;
            this.logMethod = logEverything;
        }

        public static String[] getSerialPorts()
        {
            return SerialPort.GetPortNames();
        }

        public void addHandler(string key, Action<string, string[]> handler)
        {
            if (handlers.ContainsKey(key)) throw new ArgumentException("Handler for the same key already added");
            handlers.Add(key,handler);
        }

        public void Connect(string _port,int speed)
        {
            port = new SerialPort(_port);
            port.BaudRate = speed;
            port.Open();

            receiveThread = new Thread(ReceiveJob);
            receiveThread.IsBackground = true;
            receiveThread.SetApartmentState(ApartmentState.STA);
            receiveThread.Start();

            speedThread = new Thread(speedJob);
            speedThread.IsBackground = true;
            speedThread.SetApartmentState(ApartmentState.STA);
            speedThread.Start();
        }

        private void speedJob()
        {
            int notlcv=0;
            while (true)
            {
                downloadSpeed = bytesThisTimeDown / 2;
                uploadSpeed = bytesThisTimeUp / 2;
                bytesThisTimeUp = 0;
                bytesThisTimeDown = 0;
                Thread.Sleep(2000);

                if (notlcv > 4)
                {
                    if(errorsSerialDroneSec==-1)
                    {
                        errorsSerialPCSec = ((errorsSerialPC * 8));
                        errorsSerialDroneSec = ((errorsSerialDrone * 8));
                    }
                    else
                    {
                        errorsSerialPCSec = (errorsSerialPCSec + (errorsSerialPC * 8)) / 2;
                        errorsSerialDroneSec = (errorsSerialDroneSec + (errorsSerialDrone * 8)) / 2;
                    }
                   
                    errorsSerialPC = 0;                   
                    errorsSerialDrone = 0;
                    notlcv = 0;
                } else
                {
                    notlcv++;
                }
            }
        }

        void ReceiveJob()
        {
            while(true)
            {
                try
                {
                    string readed = port.ReadTo("O_o").Replace("O_o", "");
                    Task.Run(() =>
                    {
                        try
                        {
                            bytesThisTimeDown += (readed.Length+3);
                            ProcessData(readed);
                        }                       
                        catch (Exception ex)
                        {
                            logGeneral(ex.Message);
                            Console.WriteLine("An error has ocurred when handling a response" + ex.Message);
                        }


                    });
                }
                catch (InvalidOperationException ex)
                {
                    logGeneral("Port closed!");
                    return;
                }
                catch (Exception ex)
                {
                    logGeneral(ex.Message);
                    Console.WriteLine("An error has ocurred when handling a response" + ex.Message);
                }
            }
        }

        //TMR|asd|asda|asd|adasd|asdad|adasd|asdasdO_o
        private void ProcessData(string v)
        {

            String[] a = v.Split('|');
            string id = a[0];
            int length = int.Parse(a[1]);
            String[] parameters = new string[a.Length - 2];
            for (int lcv = 0; lcv < parameters.Length; lcv++) parameters[lcv] = a[lcv + 2];

            if(String.Join("|",parameters).Length+id.Length!=length)
            {
                errorsSerialPC++;
                return;
                //throw new ArgumentException("Data integrity check failed!");
            }else
            {
                logMethod(id, String.Join("|", parameters));

                if (handlers.ContainsKey(id))
                {
                    handlers[id](id, parameters);
                }
                else
                {
                    throw new NotImplementedException("Message type " + id + " handler not defined!");
                }
            }      
        }

        public void sendMessage(string id,string data)
        {
            if (port==null||port.IsOpen == false) return;
            port.Write(id);
            port.Write("|");
            port.Write((id.Length+data.Length)+"");
            port.Write("|");
            port.Write(data);
            port.Write("@");

            bytesThisTimeUp += (id.Length+5+data.Length);
        }

        public void sendMessage(string id, string[] data)
        {
            sendMessage(id, String.Join("|", data));
      
        }

        public void Disconnect()
        {
            port.Close();
        }
    }
}
