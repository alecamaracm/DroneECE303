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

        Dictionary<string, Action<string, string[]>> handlers = new Dictionary<string, Action<string, string[]>>();

        SerialPort port;
        private Action<string, string> logMethod;

        public SerialCommunicator(Action<string,string> logEverything)
        {
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
        }

        void ReceiveJob()
        {
            while(true)
            {
                try
                {
                    ProcessData(port.ReadTo("O_o").Replace("O_o",""));
                }catch(Exception ex)
                {
                    Console.WriteLine("An error has ocurred when handling a response" + ex.Message);
                }
            }
        }

        //TMR|asd|asda|asd|adasd|asdad|adasd|asdasdO_o
        private void ProcessData(string v)
        {
            String[] a = v.Split('|');
            string id = a[0];
            String[] parameters = new string[a.Length - 1];
            for (int lcv = 0; lcv < parameters.Length; lcv++) parameters[lcv] = a[lcv + 1];

            logMethod(id, String.Join("|", parameters));

            if(handlers.ContainsKey(id))
            {
                handlers[id](id, parameters);
            }else
            {
                throw new NotImplementedException("Message type " + id + " handler not defined!");
            }
        }
    }
}
