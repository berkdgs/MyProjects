private void run_cmd(string cmd, string args)
{
     ProcessStartInfo start = new ProcessStartInfo();
     start.FileName = "D:\Documents\WorkStation\4.2-Python ile Veri Analizi\\hafta9.py";
     start.Arguments = string.Format("{0} {1}", cmd, args);
     start.UseShellExecute = false;
     start.RedirectStandardOutput = true;
     using(Process process = Process.Start(start))
     {
         using(StreamReader reader = process.StandardOutput)
         {
             string result = reader.ReadToEnd();
             Console.Write(result);
         }
     }
}