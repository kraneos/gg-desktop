# Como instalar el servicio de windows para desarrollo y testing
Es necesario ejecutar el siguiente comando
```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe <path-to-gg-desktop-repo>\Seggu.Desktop\bin\Debug\Seggu.Service.exe
```
Para poder actualizar las DLLs que el servicio utiliza para funcionar. Es necesario frenar el servicio. El comando es el siguiente:
```
net stop SegguService
```

# Como Desinstalar el servicio de windows
Es necesario ejecutar el siguiente comando
```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /u <path-to-gg-desktop-repo>\Seggu.Desktop\bin\Debug\Seggu.Service.exe
```
