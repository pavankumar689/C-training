using System.Threading;
// using System;
// using System.Collections.Generic;

// public delegate void PaymentDelegate(decimal amt);

// delegate void ErrorDelegate(string message);
// class Delegate
// {
//     public void ProcessPayment(decimal amount)
//     {
//         Console.WriteLine("processing payment of "+amount+" is successful");
//     }
//     public void RTGS(decimal amount)
//     {
//         Console.WriteLine("RTGS payment of "+amount+" is successful.");
//     }
// }
// // class Program
// // {
// //     public static void Main(string[] args)
// //     {
// //         // Delegate d=new Delegate();
// //         // PaymentDelegate payment=d.ProcessPayment;
// //         // payment+=d.RTGS;
// //         // //payment(4000);
// //         // decimal amount=5000;
// //         // if (amount.IsValidPayment())
// //         // {
// //         //     payment(amount);
// //         // }
// //         // else
// //         // {
// //         //     Console.WriteLine("Invalid payment amount");
// //         // }

// //         // function delegate
// //         // Func<decimal, decimal, decimal> calculateDiscount =(price, discount) => price -(price* discount / 100);
// //         // Console.WriteLine(calculateDiscount (1000, 10));

// //         //predicate deligate
// //         // Predicate<int> isEligible = age => age >= 18;
// //         // Console.WriteLine(isEligible(20));

// //         //anonymous delegate
// //         // ErrorDelegate errorHandler =delegate (string msg)
// //         // {
// //         // Console.WriteLine("Error:" + msg);
// //         // };
// //         // errorHandler("File not found");

// //         // Button btn=new Button();
// //         // btn.Clicked+=()=>Console.WriteLine("button clicked");
        
// //         // btn.Click();

// //     }
// // }

// static class PaymentExtensions
// {
//     public static bool IsValidPayment(this decimal amount)
//     {
//         return amount>0&&amount<=1000000;
//     }
// }

// class Button
// {
//     public delegate void ClickHandler();
//     public event ClickHandler Clicked;
//     public void Click()
//     {
//         Clicked?.Invoke();
//     }
//     public void Subscribed()
//     {
//         Clicked?.Invoke();
//     }
//     public void newsub()
//     {
//         Clicked?.Invoke();
//     }
// }

// namespace SmartHomeSecurity
// {
//     // 1. DEFINITION: The "Contract" for any security response.
//     // Any method responding to an alert must be void and take a string location.

//     public delegate void SecurityAction(string zone); // definition

//     public class MotionSensor
//     {
//         // The delegate instance (The Panic Button)
//         public SecurityAction OnEmergency; // instance creation

//         public void DetectIntruder(string zoneName)
//         {
//             Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");
            
//             // 3. INVOCATION: Triggering the Panic Button
//             if (OnEmergency != null)
//             {
//                 OnEmergency(zoneName); // string value = Main Lobby or panicSequence?
//             }
//         }
//     }

//     // Diverse classes that don't know about each other
//     public class AlarmSystem
//     {
//         public void SoundSiren(string zone) => Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
//     }

//     public class PoliceNotifier
//     {
//         public void CallDispatch(string zone) => Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
//     }

//     class Program
//     {
//         static void Main()
//         {
//             // Objects Initialization
//             MotionSensor livingRoomSensor = new MotionSensor();
//             AlarmSystem siren = new AlarmSystem();
//             PoliceNotifier police = new PoliceNotifier();

//             // 2. INSTANTIATION & MULTICASTING
//             // We "Subscribe" different methods to the sensor's delegate
//             SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
//             panicSequence += police.CallDispatch;

//             // Linking the sequence to the sensor
//             livingRoomSensor.OnEmergency = panicSequence;
// 	// class_object.delegate_instance = delegate_instance_multicast

//             // Simulation
//             livingRoomSensor.DetectIntruder("Main Lobby");
//         }
//     }
// }


namespace CallbackDemo
{
    // STEP 1: Define the Delegate
    public delegate void DownloadFinishedHandler(string fileName);

    class FileDownloader
    {
        // STEP 2: Method that accepts the callback
        public void DownloadFile(string name, DownloadFinishedHandler callback)
        {
            Console.WriteLine($"Starting download: {name}...");
            
            // Simulating work
            Thread.Sleep(2000); 
            
            Console.WriteLine($"{name} download complete.");

            // STEP 3: Execute the Callback
            if (callback != null)
            {
                callback(name); 
            }
        }
    }

    class Program
    {
        // STEP 4: The actual Callback Method
        // static void DisplayNotification(string file)
        // {
        //     Console.WriteLine($"NOTIFICATION: You can now open {file}.");
        // }

        static void Main()
        {
            // FileDownloader downloader = new FileDownloader();

            // // Pass the method 'DisplayNotification' as a callback
            // downloader.DownloadFile("Presentation.pdf", DisplayNotification);
    
            Comparison<int> sortDescending = (a, b) => b.CompareTo(a);
            Console.WriteLine(sortDescending(5,10));
            Console.WriteLine(sortDescending(10,5));
            Console.WriteLine(sortDescending(5,5));
        }
    }
}