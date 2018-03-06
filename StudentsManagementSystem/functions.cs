using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentsManagementSystem
{
    class functions
    {
        public void search(string path)
        {
            Console.WriteLine("Please Enter The Path For File");
            Console.WriteLine("Enter Id or Name or Semester You Want to Search With");
            string input1 = Console.ReadLine();
            string fileData;
            StreamReader obj = new StreamReader(path);
            while ((fileData = obj.ReadLine()) != null)
            {
                string[] fileInput = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    fileInput = fileData.Split(';');

                    if (input1 == fileInput[i])// search by ID or Name
                    {
                        Console.WriteLine("Student ID= " + fileInput[0]);
                        Console.WriteLine("Name= " + fileInput[1]);
                        Console.WriteLine("Semester= " + fileInput[2]);
                        Console.WriteLine("CGPA= " + fileInput[3]);
                        Console.WriteLine("Department= " + fileInput[4]);
                        Console.WriteLine("University= " + fileInput[5]);

                    }
                }
            }

        }
        public void createStudent(string path)
        {
            Console.WriteLine("Please Enter The Path For File");
            Console.WriteLine("Enter Student ID");
            string studentID = Console.ReadLine();
            StreamReader obj1 = new StreamReader(path);
            string[] fileData = new string[6];
            string fileInput;
            while ((fileInput = obj1.ReadLine()) != null)
            {
                fileData = fileInput.Split(';');
                if (fileData[0] == studentID)
                {
                    Console.WriteLine("Id Already Exists Enter a unique ID");
                    createStudent(path);
                }
            }
            obj1.Close();
            obj1.Dispose();
            string[] Data = new string[6];
            Data[0] = studentID;
            Console.WriteLine("Please Enter Following Details");
            Console.WriteLine("1-Student Name");
            string studentName = Console.ReadLine();
            Data[1] = studentName;
            Console.WriteLine("2-Semester");
            string semseter = Console.ReadLine(); ;
            Data[2] = semseter;
            Console.WriteLine("3-CGPA");
            string CGPA = Console.ReadLine();
            Data[3] = CGPA;
            Console.WriteLine("4-Department");
            string Department = Console.ReadLine();
            Data[4] = Department;

            Console.WriteLine("5-University");
            string University = Console.ReadLine();
            Data[5] = University;

            using (StreamWriter obj = File.AppendText(path))
            {
                obj.WriteLine(Data[0] + ";" + Data[1] + ";" + Data[2] + ";" + Data[3] + ";" + Data[4] + ";" + Data[5]);
                obj.Close();
            }
        }
        public void delete(string path, string path1)
        {
            Console.WriteLine("Enter ID You Want to delete");
            string ID = Console.ReadLine();
            StreamReader obj = new StreamReader(path);
            StreamWriter obj1 = new StreamWriter(path1);
            string fileData;
            string[] Arr = new string[1];
            while ((fileData = obj.ReadLine()) != null)
            {

                Arr = fileData.Split(';');
                if (Arr[0] != ID)
                {
                    obj1.WriteLine(fileData);
                    obj1.Close();
                }
            }
            obj.Close();
            FileStream obj2 = new FileStream(path, FileMode.Open);//delete all contents in file
            {
                obj2.SetLength(0);
                obj2.Close();
            }
            obj1.Close();
            StreamReader read = new StreamReader(path1);
            StreamWriter write = new StreamWriter(path);
            while ((fileData = read.ReadLine()) != null)
            {
                write.WriteLine(fileData);
                write.Close();
            }
        }
        public void topStudents(string path)
        {
            Console.WriteLine("Following are the Top 3 Students");
            float max = 0;
            float secondMax = 0;
            float thirdMax = 0;
            Console.WriteLine("Please Enter The Path For File");
            string fileData;
            StreamReader obj = new StreamReader(path);
            string[] fileInput = new string[6];
            float num;
            string[] displayMaxData = new String[3];
            string[] displaysecondMaxData = new String[3];
            string[] displaythirdMaxData = new String[3];
            while ((fileData = obj.ReadLine()) != null)
            {
                fileInput = fileData.Split(';');
                string GPA = fileInput[3];
                num = float.Parse(GPA);
                if (num > max)
                {
                    max = num;
                    displayMaxData[0] = fileInput[0];
                    displayMaxData[1] = fileInput[1];
                    displayMaxData[2] = fileInput[3];
                }

            }
            obj.Close();

            StreamReader obj1 = new StreamReader(path);
            while ((fileData = obj1.ReadLine()) != null)
            {
                fileInput = fileData.Split(';');
                string GPA = fileInput[3];
                num = float.Parse(GPA);
                if (num > secondMax && num < max)
                {
                    secondMax = num;
                    displaysecondMaxData[0] = fileInput[0];
                    displaysecondMaxData[1] = fileInput[1];
                    displaysecondMaxData[2] = fileInput[3];

                }

            }
            obj.Close();
            StreamReader obj2 = new StreamReader(path);
            while ((fileData = obj2.ReadLine()) != null)
            {
                string GPA = fileInput[3];
                num = float.Parse(GPA);
                if (num > thirdMax && num <secondMax)
                {
                    thirdMax = num;
                    Console.WriteLine(thirdMax);
                    displaythirdMaxData[0] = fileInput[0];
                    displaythirdMaxData[1] = fileInput[1];
                    displaythirdMaxData[2] = fileInput[3];

                }

            }
            obj.Close();
            Console.WriteLine("ID= " + displayMaxData[0]);
            Console.WriteLine("Name= " + displayMaxData[1]);
            Console.WriteLine("GPA= " + displayMaxData[2]);
            Console.WriteLine("ID= " + displaysecondMaxData[0]);
            Console.WriteLine("Name= " + displaysecondMaxData[1]);
            Console.WriteLine("GPA= " + displaysecondMaxData[2]);
            Console.WriteLine("ID= " + displaythirdMaxData[0]);
            Console.WriteLine("Name= " + displaythirdMaxData[1]);
            Console.WriteLine("GPA= " + displaythirdMaxData[2]);
        }
        public void markAttendence(string path, string path1)
        {
            Console.WriteLine("Please Enter You Department");
            string dept=Console.ReadLine();
            dept.ToLower();
            Console.WriteLine("Please Enter Semester");
            string semester=Console.ReadLine();
            StreamReader obj = new StreamReader(path);
            string fileData;
            string attendence;
            Console.WriteLine("Name" +"  " +"Present/Absent");
            while ((fileData = obj.ReadLine()) != null)
            {
                string[] fileInput = new string[3];
                    fileInput = fileData.Split(';');
                    if (dept == fileInput[4] && semester== fileInput[2])// search by ID or Name
                    {
                        using (StreamWriter ob = File.AppendText(path1))
                        {
                            Console.Write(fileInput[1]+"  ");
                            attendence = Console.ReadLine();
                            ob.WriteLine(fileInput[1]+" "+attendence);
                            ob.Close();
                        }                       
                    }
                }
            }
        public void viewAttendence(string path2)
        {
            StreamReader obj = new StreamReader(path2);
            string fileData;
            Console.WriteLine("Name"+" "+"Present/Absent");
            while ((fileData = obj.ReadLine()) != null)
            {

                Console.WriteLine(fileData);
            }
            obj.Close();
        }
            
     }
}

