using System;
using System.Threading;
using System.Windows.Forms;

namespace DependencyMapper
{
  static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.ThreadException += HandleUnhandledException;
      Application.Run(new MainForm());
    }

    private static void HandleUnhandledException(
      object sender,
      ThreadExceptionEventArgs args)
    {
      MessageBox.Show(
        $"{args?.Exception?.Message}{Environment.NewLine}{Environment.NewLine}{args.Exception.StackTrace}",
        "Unhandled Exception",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error);
    }
  }
}
