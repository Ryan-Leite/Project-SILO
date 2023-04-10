using System;
using System.Net.Sockets;
using System.Windows.Forms;
using FRRobot;

namespace FanucTesting_V1A
{
    public partial class Form1 : Form
    {
        private FanucConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            string ipAddress = IPAddress.Text;

            // Connect to the robot using the PCDK library
            connection = new FanucConnection(ipAddress, 21);

            // Add your code to handle faults and alarms here
            //Robot_FaultOccur;
            // Get the current robot alarm

            if (connection.robot.Alarms.ActiveAlarms)
            {
                FRCAlarm alarm = connection.robot.Alarms[0];

                // Check the alarm properties to determine its type and severity
                string message = "Robot alarm occurred!\n\n";
                message += "Type: " + connection.robot.Alarms.Count + "\n";
                message += "Severity: " + alarm.SeverityMessage + "\n";
                message += "Code: " + alarm.ErrorMessage + "\n";
                message += "Time: " + alarm.TimeStamp + "\n";
                message += "Message: " + alarm.ErrorMnemonic + "\n\n";
                //message += "Additional info:\n" + e.AdditionalInfo;

                MessageBox.Show(message, "Robot Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Robot_FaultOccur(object sender)
        {
            // Get the current robot alarm
            FRCAlarm alarm = connection.robot.Alarms[0];

            // Check the alarm properties to determine its type and severity
            string message = "Robot alarm occurred!\n\n";
            message += "Type: " + alarm.GetType() + "\n";
            message += "Severity: " + alarm.SeverityMessage + "\n";
            message += "Code: " + alarm.GetHashCode() + "\n";
            message += "Message: " + alarm + "\n\n";
            //message += "Additional info:\n" + e.AdditionalInfo;

            MessageBox.Show(message, "Robot Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Define a class to represent the Fanuc robot connection
    class FanucConnection
    {
        // Declare private variables to store the connection information
        private string ipAddress;
        private int port;
        private NetworkStream stream;
        public FRCRobot robot;

        // Define a constructor to initialize the connection
        public FanucConnection(string ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;

            try
            {
                // Connect to the robot using the PCDK library
                TcpClient client = new TcpClient(ipAddress, port);
                stream = client.GetStream();
                robot = new FRCRobot();
                robot.Connect(this.ipAddress);

                MessageBox.Show("Successfully connected to the robot at " + ipAddress, "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                MessageBox.Show("Error connecting to the robot: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
