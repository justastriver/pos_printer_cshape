using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using GprinterTest;
using System.Threading;

namespace POSdllDemo
{
    public partial class Form1 : Form
    {
        private IntPtr Gp_IntPtr;                   //驱动打印句柄
        LoadPOSDll PosPrint = new LoadPOSDll();
        private libUsbContorl.UsbOperation NewUsb = new libUsbContorl.UsbOperation();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
						//POS_COM_DTR_DSR 0x00 流控制为DTR/DST  
						//POS_COM_RTS_CTS 0x01 流控制为RTS/CTS 
						//POS_COM_XON_XOFF 0x02 流控制为XON/OFF 
						//POS_COM_NO_HANDSHAKE 0x03 无握手 
						//POS_OPEN_PARALLEL_PORT 0x12 打开并口通讯端口 
						//POS_OPEN_BYUSB_PORT 0x13 打开USB通讯端口 
						//POS_OPEN_PRINTNAME 0X14 打开打印机驱动程序 
						//POS_OPEN_NETPORT 0x15 打开网络接口 

            if (PosPrint.OpenNetPort("192.168.0.123"))//当参数nParam的值为POS_OPEN_NETPORT时，表示打开指定的网络接口，如“192.168.10.251”表示网络接口IP地址，打印时参考
            {
                Gp_IntPtr = PosPrint.POS_IntPtr;
            }
            if (LoadPOSDll.POS_StartDoc())
            {
                byte[] by_SendData = System.Text.Encoding.Default.GetBytes("test print\r\n");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, by_SendData, (uint)by_SendData.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_EndDoc();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //POS_COM_DTR_DSR 0x00 流控制为DTR/DST  
            //POS_COM_RTS_CTS 0x01 流控制为RTS/CTS 
            //POS_COM_XON_XOFF 0x02 流控制为XON/OFF 
            //POS_COM_NO_HANDSHAKE 0x03 无握手 
            //POS_OPEN_PARALLEL_PORT 0x12 打开并口通讯端口 
            //POS_OPEN_BYUSB_PORT 0x13 打开USB通讯端口 
            //POS_OPEN_PRINTNAME 0X14 打开打印机驱动程序 
            //POS_OPEN_NETPORT 0x15 打开网络接口 

            if (PosPrint.OpenPrinter("Gprinter 2120TU"))//当参数nParam的值为POS_OPEN_NETPORT时，表示打开指定的网络接口，如“192.168.10.251”表示网络接口IP地址，打印时参考
            {
                Gp_IntPtr = PosPrint.POS_IntPtr;
            }
            if (LoadPOSDll.POS_StartDoc())
            {
                byte[] by_SendData = System.Text.Encoding.Default.GetBytes("test print\r\n");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, by_SendData, (uint)by_SendData.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_EndDoc();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
        	NewUsb.FindUSBPrinter();
        	for(int i=0;i<NewUsb.USBPortCount;i++)
        	{
        		if(NewUsb.LinkUSB(i))
        		{
        			byte[] shiftsize={0x1d,0x57,0xd0,0x01};//偏移量
        			byte[] KanjiMode={0x1c,0x26};//汉字模式
        			
        			SendData2USB(shiftsize);
        			SendData2USB(KanjiMode);
        			
        			#region 打印信息测试
        			string strPrintwidth="48毫米";
        			string strPrintDensity="384点/行";
        			string strPrintSpeed="90毫米/秒";
        			string strPrintLiftTime="50公里";
        			string strPowerSupply="DC 12V/4A";
        			string strSerialInfo="有";
        			string strParInfo="无";
        			string strUSBInfo="USB2.0协议";
        			string strWirelessInfo="无";
        			string strNetInfo="无";
        			
        			string strSend;
        			byte[] SendData={0x1b,0x61,0x01,0x1b,0x21,0x30,0x1c,0x57,0x01};
        			byte[] enddata={0x0a};//换行
        			
        			SendData2USB(SendData);
        			
        			string strSendData="联机测试";
        			SendData2USB(strSendData);
        			
        			SendData2USB(new byte[]{0x0a,0x0a});
        			SendData2USB(new byte[]{0x1b,0x61,0x00,0x1b,0x21,0x00,0x1c,0x57,0x00});
        			
        			SendData2USB("技术指标：");
        			SendData2USB(enddata);
        			SendData2USB("*打印宽度"+strPrintwidth);
        			SendData2USB(enddata);
        			SendData2USB("*打印速度"+strPrintSpeed);
        			SendData2USB(enddata);
        			SendData2USB("*打印浓度"+strPrintDensity);
        			SendData2USB(enddata);
        			SendData2USB("*使用寿命"+strPrintLiftTime);
        			SendData2USB(enddata);
        			SendData2USB("*电源要求"+strPowerSupply);
        			SendData2USB(enddata);
        			SendData2USB("*打印宽度"+strPrintwidth);
        			SendData2USB(enddata);
        			SendData2USB("*串行接口"+strSerialInfo);
        			SendData2USB(enddata);
        			SendData2USB("*并行接口"+strParInfo);
        			SendData2USB(enddata);
        			SendData2USB("*USB接口"+strUSBInfo);
        			SendData2USB(enddata);
        			SendData2USB("*无线接口"+strWirelessInfo);
        			SendData2USB(enddata);
        			SendData2USB("*网络接口"+strWirelessInfo);
        			SendData2USB(enddata);
        			SendData2USB(enddata);
        			#endregion
        			
        			#region 字体打印测试
        			SendData2USB(KanjiMode);
					SendData=new byte[16];
					int linecount=3;
					byte bit=0xa1,Zone=0xa1;
					for(i=0;i<16;i+=2)
					{
						SendData[i]	=Zone;
						SendData[i+1]=bit;
						bit++;
					}
        			SendData2USB(enddata);
        			SendData2USB(SendData);
        			
        			Zone=0xb0;
        			bit=0xa1;
        			for(i=0;i<linecount;i++)
        			{
        				for(int j=0;j<16;j+=2)
        				{
        					SendData[j]=Zone;
        					SendData[j+1]=bit;
        					Zone++;
        				}
        				bit++;
	        			SendData2USB(enddata);
	        			SendData2USB(SendData);
        			}
        			SendData2USB(enddata);
        			SendData2USB(enddata);
        			#endregion
        			
                    NewUsb.CloseUSBPort();
        		}
        	}
        }

        private void btn_GetPrinterState_Click(object sender, EventArgs e)
        {
            NewUsb.FindUSBPrinter();
            if(NewUsb.USBPortCount>0)//number of available USB ports 
            {
                if (NewUsb.LinkUSB(0))//Connect USB0 ;; 
                {
                    Thread Readthread = new Thread(new ThreadStart(delegate
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            btn_GetPrinterState.Enabled = false;
                        }));
                        SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                        byte[] GD = new byte[] { };
                        NewUsb.ReadDataFmUSB(ref GD);
                        byte bufbak = GD[0];
                        string strreturn = "";
                        if ((bufbak & 0x12) == 0x12)
                        {
                            if ((bufbak & 0x04) == 0x04)
                                strreturn += "cashbox is close\r\n";
                            else
                                strreturn += "cashbox is open\r\n";
                            if ((bufbak & 0x08) == 0x08)
                                strreturn += "offline\r\n";
                            else
                                strreturn += "online\r\n";
                        }
                        else
                        {
                            strreturn += "Unknown code\r\n";
                        }
                        this.Invoke(new MethodInvoker(() =>
                        {
                            lbGetState.Text = strreturn;
                            NewUsb.CloseUSBPort();
                            btn_GetPrinterState.Enabled = true;
                        }));
                    }));
                    Readthread.IsBackground = true;
                    Readthread.Start();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
        	NewUsb.FindUSBPrinter();
        	for(int i=0;i<NewUsb.USBPortCount;i++)
        	{
        		if(NewUsb.LinkUSB(i))
        		{
        			SendData2USB("SIZE 58 mm,60 mm\r\n");//标签尺寸
        			SendData2USB("GAP 0 mm,0 mm\r\n");//间距为0
        			SendData2USB("DENSITY 7\r\n");//打印浓度
        			SendData2USB("REFERENCE 0,0\r\n");
        			SendData2USB("TEXT 15,10,\"1\",0,1,1,\"asdfggDDD\"\r\n");
        			SendData2USB("TEXT 15,60,\"TSS24.BF2\",0,1,1,\"简体字\"\r\n");
        			
        			StreamReader strReadFile=new StreamReader(@"./10.bmp");
        			byte[] byteReadData=new byte[strReadFile.BaseStream.Length];
        			strReadFile.BaseStream.Read(byteReadData,0,byteReadData.Length);
        			strReadFile.Close();
        			SendData2USB("DOWNLOAD\"10.bmp\",4096,");
        			SendData2USB(byteReadData);//bmp数据
        			SendData2USB("PUTBMP 14,110,\"10.bmp\"\r\n");
        			SendData2USB("PRINT 1\r\n");
        			
        			NewUsb.CloseUSBPort();
        		}
        	}
        }
        private void SendData2USB(byte[] str)
        {
        	NewUsb.SendData2USB(str,str.Length);
        }
        private void SendData2USB(string str)
        {
        	byte[] by_SendData=System.Text.Encoding.Default.GetBytes(str);
        	SendData2USB(by_SendData);
        }
        private void button4_Click(object sender, EventArgs e)
        {
					if(serialPort1==null)
					{
						serialPort1=new SerialPort();
						serialPort1.RtsEnable=true;
					}
					if(serialPort1.IsOpen)
					{
						serialPort1.Close();
					}
					serialPort1.PortName="COM1";
					serialPort1.BaudRate=19200;
					serialPort1.Parity=(Parity)Enum.Parse(typeof(Parity),"None");
					serialPort1.DataBits=8;
					serialPort1.StopBits=(StopBits)Enum.Parse(typeof(StopBits),"One");
					serialPort1.ReadBufferSize=100;
					serialPort1.WriteBufferSize=2048;
					serialPort1.ReadTimeout=100;
					serialPort1.WriteTimeout=10000;
          if(PosPrint.OpenComPort(ref serialPort1))
          {
          	LoadPOSDll.POS_Reset();
          	IntPtr[] pathPtr=new IntPtr[4];
          	pathPtr[0]=Marshal.StringToHGlobalAnsi(@"./09.bmp");
          	pathPtr[1]=Marshal.StringToHGlobalAnsi(@"./08.bmp");
          	pathPtr[2]=Marshal.StringToHGlobalAnsi(@"./07.bmp");
          	pathPtr[3]=Marshal.StringToHGlobalAnsi(@"./06.bmp");
          	PosPrint.DownloadBmpsToFlash(pathPtr,4);
          	
          	LoadPOSDll.POS_EndDoc();
          	Marshal.FreeHGlobal(pathPtr[0]);
          	Marshal.FreeHGlobal(pathPtr[1]);
          	Marshal.FreeHGlobal(pathPtr[2]);
          	Marshal.FreeHGlobal(pathPtr[3]);
          	PosPrint.ClosePrinterPort();
          }
        }
        private void button5_Click(object sender, EventArgs e)
        {
			if(serialPort1==null)
			{
			serialPort1=new SerialPort();
			serialPort1.RtsEnable=true;
			}
			if(serialPort1.IsOpen)
			{
			serialPort1.Close();
			}
			serialPort1.PortName="COM1";
			serialPort1.BaudRate=19200;
			serialPort1.Parity=(Parity)Enum.Parse(typeof(Parity),"None");
			serialPort1.DataBits=8;
			serialPort1.StopBits=(StopBits)Enum.Parse(typeof(StopBits),"One");
			serialPort1.ReadBufferSize=100;
			serialPort1.WriteBufferSize=2048;
			serialPort1.ReadTimeout=100;
			serialPort1.WriteTimeout=10000;
          if(PosPrint.OpenComPort(ref serialPort1))
          {
          	LoadPOSDll.POS_Reset();
          	PosPrint.PrintBmpInFlash(1,0,0x00);
          	PosPrint.PrintBmpInFlash(2,0,0x00);
          	PosPrint.PrintBmpInFlash(3,0,0x00);
          	PosPrint.PrintBmpInFlash(4,0,0x00);
          	PosPrint.ClosePrinterPort();
          }
        }

        private void btCheckMarkGo_Click(object sender, EventArgs e)
        {
            bool printpoint = true; //打印起始位置
            bool front = true;      //前进
            int resultLength = int.Parse(tbCheckMarkGo.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btCheckMarkBack_Click(object sender, EventArgs e)
        {
            bool printpoint = true; //打印起始位置
            bool front = false;
            int resultLength = int.Parse(tbCheckMarkBack.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btCutMarkGo_Click(object sender, EventArgs e)
        {
            bool printpoint = false; // 切/撕纸位置
            bool front = true;
            int resultLength = int.Parse(tbCutMarkGo.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btCutMarkBack_Click(object sender, EventArgs e)
        {
            bool printpoint = false; // 切/撕纸位置
            bool front = false;
            int resultLength = int.Parse(tbCutMarkBack.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btPrintGoNext_Click(object sender, EventArgs e)
        {
            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                LoadPOSDll.POS_Reset();

                byte[] data1 = System.Text.Encoding.Default.GetBytes("开始打印");
                byte[] data2 = System.Text.Encoding.Default.GetBytes("然后走纸到下一个起始打印位置");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data1, (uint)data1.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[]{0x0a}, 1);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data2, (uint)data2.Length);

                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1B, 0x64, 0x05, 0x0A }, 4);//打印并进纸 n 行(0x05行)
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1D, 0x54, 0x1D, 0x0C }, 4);//进黑标纸至打印起始位置(1D 0C)
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0D }, 1);//把打印起始位置设置为该行的开始

                PosPrint.ClosePrinterPort();
            }
        }

        private void btPrintGoNextCut_Click(object sender, EventArgs e)
        {
            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                LoadPOSDll.POS_Reset();

                byte[] data1 = System.Text.Encoding.Default.GetBytes("开始打印");
                byte[] data2 = System.Text.Encoding.Default.GetBytes("然后走纸到下一个/撕纸位置");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data1, (uint)data1.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data2, (uint)data2.Length);

                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1B, 0x64, 0x05, 0x0A }, 4);//打印并进纸 n 行(0x05行)
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1D, 0x54, 0x1D, 0x56, 0x30 }, 5);//一种切纸模式并切纸(1D 56)30 31
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0D }, 1); //把打印起始位置设置为该行的开始

                PosPrint.ClosePrinterPort();
            }
        }
    }
}
