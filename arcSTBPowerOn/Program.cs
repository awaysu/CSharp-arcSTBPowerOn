/*
 * 由SharpDevelop创建。
 * 用户： jason_su
 * 日期: 08/10/2022
 * 时间: PM 12:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO.Ports;
using System.Threading;

namespace arcSTBPowerOn
{
	class Program
	{
		
		public static void setCom(int port, int onoff)
		{
			SerialPort serialPort = new SerialPort();	
            serialPort.PortName = "COM" + port.ToString();
            serialPort.BaudRate = 9600;            // baud rate = 9600
            serialPort.Parity = Parity.None;       // Parity = none
            serialPort.StopBits = StopBits.One;    // stop bits = one
            serialPort.DataBits = 8;               // data bits = 8

            serialPort.Open();
            serialPort.DiscardInBuffer();       // RX
            serialPort.DiscardOutBuffer();      // TX
						
			try
			{				
				if (serialPort.IsOpen)
				{
					Thread.Sleep(500);
					
					Console.WriteLine("Set COM" + port.ToString() + " Successfully!");

					
					if (onoff == 0)
					{
		                serialPort.RtsEnable = false;
		                serialPort.DtrEnable = false;
		                Console.WriteLine("Set COM" + port.ToString() + " OFF!");
					}
					else
					{
		                serialPort.RtsEnable = true;
		                serialPort.DtrEnable = true;
		                Console.WriteLine("Set COM" + port.ToString() + " ON!");
					}
					
					while(true)
					{
						Thread.Sleep(10);
					}
					
				}
				
				//serialPort.Close();
			}
            catch (Exception)
            {
            	//Console.WriteLine("Set COM" + port.ToString() + " failed!");
            }
            finally
            {
            	serialPort.Close();
            }
			
		}
		
		public static void Main(string[] args)
		{
			Console.Write("\r\nPower ON command :\r\n");
			Console.Write("cmd /c start /min arcSTBPowerOn.exe {com port}\r\n\r\n");
			Console.Write("Power OFF command :\r\n");
			Console.Write("taskkill /IM arcSTBPowerOn.exe /F\r\n\r\n\r\n");
			Console.Write("");

	        if (args == null || args.Length == 0)
	        {
	            Console.WriteLine("Args is null");
	        }
	        else
	        {
	        	if ( args[0] != null  )
	        	{
	        		//Console.Write(args[1].ToString());
	        		//setCom(Int32.Parse(args[0]), Int32.Parse(args[1]));
	        		setCom(Int32.Parse(args[0]), 1);
	        	}
     	   }
		}
	}
}