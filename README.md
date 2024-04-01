# HHMHQMS
Queueing System of HHMH

QMS is a home-grown software originally from SEHI, then upgraded in West Metro, and now with further upgrade at Howard. So, this is free to share within MPH sister hospitals.

 
Hi, this is Jaz from West Metro Medical Center. 
I am the developer this software.

Before you can run this software, there are some things you need to setup or else,
the software will not run properly or may have issues with some important features.

These are the following  things you need to set up:

1) Crystal Report - i used crystal report as a tool for reporting (e.g Print Reports). 
	It is a 3rd Party Software, hence you need to install this on the client's computer.

	File Locations: 
	-> \\192.168.11.198\HHMH Files\QMS\Application File\Prerequisites\CR13SP29MSI64_0-10010309.MSI
	-> \\192.168.11.198\HHMH Files\QMS\Application File\Prerequisites\CRRuntime_64bit_13_0_12.msi
			
	If you are a developer and your debuging the system using Visual Studio, you need to install the crystal report
	for visual studio.
				
	File Location:
	-> \\192.168.11.198\HHMH Files\QMS\Application File\Prerequisites\CRforVS13SP29_0-10010309.msi

2) Wacom Signature SDK - i used Wacom Signature Pad STU-430 for Digital Signatures and this requires you to install
	the wacom signature sdk. 

	File Locations:
	For 86 Bit Computer -> \\192.168.11.198\HHMH Files\QMS\Application File\Prerequisites\Wacom-Signature-SDK-x86-4.7.1.msi
	For 64 Bit Computer -> \\192.168.11.198\HHMH Files\QMS\Application File\Prerequisites\Wacom-Signature-SDK-x64-4.7.1.msi


For the Next item below are optional

3) Epson TM-T82x Thermal Printer Driver - thermal printer or any small printer can be use here. But i used 
							Epson TM-T82x Thermal Printer in West Metro. If you are using the same
							printer, you may install the Driver for this printer. If not, you may just
							download the driver of your printer on the Vendor's Website.

	File Locations:
	->\\192.168.11.198\HHMH Files\QMS\Application File\Prerequisites\APD_604_T82X.exe

=================================================================================================================================

If you don't know how to run the App on the Client's Computer, all you need to do are the following:
1) Right Click HHMHQMS (Aplication Manifest).
2) Click Send to, then select Desktop (Create Shorcut)
3) On your desktop, double left click the shortcut files to open.
Bellow may change depends on the Computer. (Windows 10 and 11 have this)
4) If a security warning appears, just click "RUN". 
5) If Windows protect your PC appears, just click "More Info" then click "Run Anyway"


There you go. You are all set up now and ready to go. You may now use the application on the client's computer.
But take note! As the technology upgrades, this system may be unable to run on some device or the requirements 
may change. If you need help, don't hessitate to call me
	-> 09060212419 GLOBE
	-> 09978215844 TM
	-> Jascha Mascuñana - Facebook/Messanger
