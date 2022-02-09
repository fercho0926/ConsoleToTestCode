using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class ExceptionClass
    {

        public void exceptionCrashMessage(string message)
        {
            //This Exeption crash the program
            throw new ArgumentException($"Invalid {nameof(message)}");
        }

        public void tryCatch() {

            try
            {
                throw new Exception("go to catch");
            }


            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex) // check the format
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex) // this exception catch any any exception
            {
                Console.WriteLine(ex.Message);
            }
            finally // codigo que SIEMPRE SIEMPRE SIEMPRE se va a ejecutar
            { 
            // code to execute
            }
        }





    }


   





}
