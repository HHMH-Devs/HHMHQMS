
STU SDK for Windows Desktop

Version 2.15.5

----------------------------------------------------------------------------------------------------------------
About

The Wacom STU SDK provides a software interface to the STU series tablets.
The SDK installer copies API documentation to the COM\doc folder.
STU SigCaptX is included for cross-browser support when javascript is unable to access the STU ActiveX component.

For further details on using the SDK see https://developer-docs.wacom.com
Navigate to: Wacom Ink Connectivity...STU SDK
References are included to the SDK sample code on GitHub

----------------------------------------------------------------------------------------------------------------
File Contents

documentation\
  STU-SDK Getting Started.pdf       - Getting started guide
  STU-SDK Redistribution.pdf        - Deployment guide
  STU-SigCaptX-Guide.pdf            - Cross browser guide

STU-SDK\
  Wacom-STU-SDK-x86-2.15.4.msi      - Windows installer
                                      includes 32 and 64-bit components, documentation and samples

STU-SigCaptX\
  Wacom-STU-SigCaptX-x86-1.4.7.msi  - Windows installer
  Wacom-STU-SigCaptX-1.4.7.exe      - Windows Combined installer includes STU-SDK components and STU driver
  
      
----------------------------------------------------------------------------------------------------------------
Version History

STU SDK

    Release 2.15.5  29-May-2020
      Rebuilt zip file

    Release 2.15.4  21-Apr-2020
      SDK installer rebuilt to exclude samples
      Samples available here: https://github.com/Wacom-Developer/wacom-device-kit-stu-sdk-samples

    Release 2.15.3  23-Aug-2019
      Workaround for failure to initialize STU-540 correctly with Java
      Rebuild to counteract anti-virus false positives in STU SigCaptX

    Release 2.15.2  19-Jun-2019
      Added OpenSSL DLLs (Windows Java folders only) to SDK installer
  
    Release 2.15.1b  25-Mar-2019
      Incremented SigCaptX version  
      Fix for 64-bit Java when loading OpenSSL libraries
			
    Release 2.15.1 2019-02-15
      - OpenSSL v1.1 
      - Fix to writeImageArea()
 
    Release 2.14.1 2018-08-21
      Fixes for 24-bit colour and getUID2()

    Release 2.13.6 2018-02-16
      Various Linux fixes including report lengths, libusb, makefile

    Release 2.13.5 2018-01-16
      Updated installed DemoButtons sample for STU-540 
      Added root certificate for STU-541 certificate exchange validation
      Added mutex locking to Tablet class in case of multi-threaded calls

    Release 2.13.4 2017-10-04
      Added Java support for STU-541
      Made OpenSLL DLLs load on demand (wgssSTU.dll)

    Release 2.13.3 2017-07-04
      Rebuild for STU-SigCaptX
      Added Linux support for STU-540/541
      STU-541 C++ only

    Release 2.13.1  2017-03-27
      Added C support for STU-540
      Added Java support for STU-540
      Fixed issues in Linux: 32-bit build for Ubuntu 12.04.05 LTS added

STU SigCaptX

  Release v1.4.6  12-Jul-2019
    Rebuild Mozilla NSS tools with current source to counteract false positives in some AV engines
	
  Release v1.4.5  13-Jun-2019
    Remove installer option to allow cross-domain scripting in IE11
	
  Release v1.4.4  20-May-2019
    Provide installer option to allow cross-domain scripting in IE11
		
  Release v1.4.3  19-Feb-2019
    Fix for writeImageArea() 

  Release v1.4.2  22-Nov-2018
    Fixes for low-level API calls including pen colour and UID2
    Migration to VS2017
    Fix to Protocol and Tablet setHandwritingThicknessColor24

  Release v1.4.0  20-Feb-2018
    Fix for revised Firefox certificate database

  Release v1.3.0  17-Jan-2018
    Updated with STU SDK 2.13.5
	
  Release v1.2.0  04-July-2017
    Added support for STU-540/541
    Fix for issue with IE11, Edge browsers
	
  Release v1.1.4  15-February-2017
    Combined installer executable added for STU SigCaptX plus STU driver
	
  Release v1.1.3  27-January-2017
    Public release
    
  Release v1.1.3  24-November-2016
    EULA added to installer

  Release v1.0.1  09-February-2016
    Initial release.
 

    
Copyright © 2020 Wacom, Co., Ltd. All Rights Reserved.

