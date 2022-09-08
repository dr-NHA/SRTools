using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace NHA_SRTools{
public partial class MainWindow : Form{

private int UnPackingAmount = 0;
private int PackingAmount=0;
private string ExtractionString="";

public MainWindow(string[] Args){
InitializeComponent();
Application.ApplicationExit += (X, E) => {
foreach (Process P in Processes)
try{
if(!P.HasExited)
P.Kill();
}catch(Exception E2) { 
                    
}};

void AutoHandleFile(string PATH) { 
if(!Unpack(PATH))
Debug.WriteLine("Cannot Unpack: "+ PATH);
}

if (Args.Length > 0)
AutoHandleFile(Args[0]);

#region Drag And Drop Files
AllowDrop = true;
DragEnter +=(X, E) => {
if (E.Data.GetDataPresent(DataFormats.FileDrop))
E.Effect = DragDropEffects.Copy;
};
DragDrop += (X, E) => {
foreach (string file in (string[])E.Data.GetData(DataFormats.FileDrop))
AutoHandleFile(file); 
};
#endregion

OpenFile.FileOk += (X, E) =>Unpack(OpenFile.FileName);
UnpackButton.Click += (X, E) =>OpenFile.ShowDialog();
UnpackButton.Text="Unpack File";
            
STATE? CurrentState=null;
UI_Thread.Tick += (X, E) => { 
if(Output.Text!= ExtractionString){
Output.Text = ExtractionString;
Output.ScrollToEnd();
}
if (UnPackingAmount > 0) 
CurrentState=STATE.Unpacking; 
else
CurrentState=STATE.Idle;  

if(!CurrentState.HasValue)
CurrentState=STATE.Idle;  

SetState(CurrentState.Value);
};

Threads.Value = SrTool.Threads;
Threads.ValueChanged += (X, E) => SrTool.Threads=(int) Threads.Value;
}


public enum STATE { 
Idle,
Unpacking,
Packing
}
public void SetState(STATE STATE) { 
State.Text = 
(STATE == STATE .Idle)? "Idle!" :
(STATE == STATE.Unpacking) ? $"Unpacking: {UnPackingAmount} File!" :
(STATE == STATE.Packing) ? $"Packing: {PackingAmount} File!" :
"?";        
}

        
public void AddToOutput(string Text) {
if (ExtractionString.Length==0)
ExtractionString = Text;
else
ExtractionString+= "\n"+Text;
}

private void UnpackCompleted(string Path) { 
AddToOutput(Path+ ": Unpacking Finished!");
UnPackingAmount--;
}

private List<Process> Processes=new List<Process>();

private bool Unpack(string Path) { 
if (Path.EndsWith(".vpp_pc")|| Path.EndsWith(".str2_pc") || Path.EndsWith(".vss_crunched_pc")) {//EXTRACT
AddToOutput(Path+": Unpacking Started!"); 
UnPackingAmount++;
var P= SrTool.UnpackFile(Path, AddToOutput, () => UnpackCompleted(Path));
Processes.Add( P);
P.Exited+=(X,E)=> Processes.Remove(P);
return true;
}  
return false;
}



}
}
