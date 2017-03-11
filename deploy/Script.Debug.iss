; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Seggu"
#define MyAppVersion "1.0"
#define MyAppPublisher "Seggu"
#define MyAppURL "http://www.seggu.com.ar"
#define MyAppExeName "SeGGu.exe"
#define AppBasePath "..\app"
#define AppSourcesPath "{#AppBasePath}\Seggu.Desktop\bin\Debug"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AD32A9D8-EBC7-48D9-9E13-2F0576752FAB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={sd}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
OutputDir=.\output
OutputBaseFilename=Instalador Seggu
SetupIconFile={#AppBasePath}\Seggu.Desktop\Resources\SeGGu Logo.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: ..\app\Seggu.Desktop\bin\Debug\*; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs;
Source: ..\app\Seggu.Desktop\bin\Debug\seggu.sqlite; DestDir: "{app}"; Permissions: everyone-full; Flags: ignoreversion 
; NOTE: Don't use "Flags: ignoreversion" on any shared system files


[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: {dotnet40}\installutil.exe; Parameters: Seggu.Service.exe; WorkingDir: {app}; StatusMsg: "Service install"; Flags: ShellExec RunHidden; 
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallRun] 
Filename: {dotnet40}\installutil.exe; Parameters: "/u Seggu.Service.exe"; WorkingDir: {app}; StatusMsg: "Service install"; Flags: ShellExec RunHidden;


