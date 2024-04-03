USE [master]
GO
/****** Object:  Database [hhmhqueueingdb]    Script Date: 4/3/2024 10:02:46 AM ******/
CREATE DATABASE [hhmhqueueingdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hhmhqueueingdb', FILENAME = N'E:\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\hhmhqueueingdb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hhmhqueueingdb_log', FILENAME = N'F:\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\Data\hhmhqueueingdb_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [hhmhqueueingdb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hhmhqueueingdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hhmhqueueingdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hhmhqueueingdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hhmhqueueingdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hhmhqueueingdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hhmhqueueingdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET RECOVERY FULL 
GO
ALTER DATABASE [hhmhqueueingdb] SET  MULTI_USER 
GO
ALTER DATABASE [hhmhqueueingdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hhmhqueueingdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hhmhqueueingdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hhmhqueueingdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hhmhqueueingdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hhmhqueueingdb] SET QUERY_STORE = OFF
GO
USE [hhmhqueueingdb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [hhmhqueueingdb]
GO
/****** Object:  Schema [m2ss]    Script Date: 4/3/2024 10:02:46 AM ******/
CREATE SCHEMA [m2ss]
GO
/****** Object:  Schema [wmmcqms]    Script Date: 4/3/2024 10:02:46 AM ******/
CREATE SCHEMA [wmmcqms]
GO
/****** Object:  Table [dbo].[bizbox_consultation]    Script Date: 4/3/2024 10:02:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bizbox_consultation](
	[consultation_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[datemodified] [datetime] NULL,
	[opdconsent1] [nvarchar](max) NULL,
	[opdconsent2] [nvarchar](max) NULL,
	[isServed] [smallint] NOT NULL,
	[forinitialconsult_serverassigncounter_ID] [bigint] NULL,
	[FK_psPatRegisters] [bigint] NOT NULL,
	[FK_emdPatients] [bigint] NOT NULL,
	[info_id] [bigint] NOT NULL,
	[servertransaction_id] [bigint] NOT NULL,
	[servedcustomer_id] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[counterboard]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[counterboard](
	[counterboarditem_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[displayname] [nvarchar](20) NOT NULL,
	[displayctr] [int] NOT NULL,
	[counter_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[counterboardtransaction]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[counterboardtransaction](
	[counterboarditem_id] [bigint] NOT NULL,
	[counter_id] [bigint] NOT NULL,
	[servertransaction_id] [bigint] NOT NULL,
	[datetimelogged] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customerinfo]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerinfo](
	[info_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[firstname] [varchar](50) NULL,
	[middlename] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[sex] [varchar](15) NULL,
	[birthdate] [date] NULL,
	[civilstatus] [varchar](50) NULL,
	[street] [varchar](50) NULL,
	[barangay] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[phonenumber] [varchar](50) NULL,
	[nationality] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[picturelocation] [varchar](100) NOT NULL,
	[FK_emdPatients] [bigint] NULL,
	[province] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customerotherinfo]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerotherinfo](
	[OtherInfo_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Info_ID] [bigint] NULL,
	[ID_Type] [varchar](max) NULL,
	[ID_Number] [varchar](max) NULL,
	[Valid_Until] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customerprescription]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerprescription](
	[prescription_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[productcode] [bigint] NOT NULL,
	[productdescription] [varchar](50) NULL,
	[genericname] [varchar](max) NULL,
	[qty] [int] NULL,
	[strength] [varchar](100) NULL,
	[preparation] [varchar](20) NULL,
	[instruction] [varchar](max) NULL,
	[unitprice] [real] NULL,
	[unitcost] [real] NULL,
	[onhand] [int] NULL,
	[beforebreakfast] [varchar](20) NULL,
	[beforelunch] [varchar](20) NULL,
	[beforedinner] [varchar](20) NULL,
	[afterbreakfast] [varchar](20) NULL,
	[afterlunch] [varchar](20) NULL,
	[afterdinner] [varchar](20) NULL,
	[atbedtime] [smallint] NOT NULL,
	[daysIntake] [int] NOT NULL,
	[sentdate] [datetime] NULL,
	[requestdate] [datetime] NOT NULL,
	[modifieddate] [datetime] NULL,
	[FK_emdPatients] [bigint] NOT NULL,
	[servertransaction_id] [bigint] NOT NULL,
	[info_id] [bigint] NOT NULL,
	[vital_id] [bigint] NULL,
	[isS2] [smallint] NOT NULL,
	[ctr] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customervitals]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customervitals](
	[consultation_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[weight] [float] NULL,
	[weightunit] [char](10) NULL,
	[height] [float] NULL,
	[heightunit] [char](10) NULL,
	[systolic] [float] NULL,
	[diastolic] [float] NULL,
	[temperature] [float] NULL,
	[pulserate] [float] NULL,
	[respiratoryrate] [float] NULL,
	[oxygen] [float] NULL,
	[pain] [nvarchar](100) NULL,
	[painlocation] [nvarchar](100) NULL,
	[hypertension] [smallint] NOT NULL,
	[diabetes] [smallint] NOT NULL,
	[asthma] [smallint] NOT NULL,
	[hearthdisease] [smallint] NOT NULL,
	[arthritis] [smallint] NOT NULL,
	[cancer] [smallint] NOT NULL,
	[tuberculosis] [smallint] NOT NULL,
	[stroke] [smallint] NOT NULL,
	[copd] [smallint] NOT NULL,
	[transferredreferred] [smallint] NOT NULL,
	[refusedadmission] [smallint] NOT NULL,
	[erdeath] [smallint] NOT NULL,
	[discharged] [smallint] NOT NULL,
	[forfollowup] [smallint] NOT NULL,
	[absconed] [smallint] NOT NULL,
	[hamadam] [smallint] NOT NULL,
	[doa] [smallint] NOT NULL,
	[admitted] [smallint] NOT NULL,
	[admittedroom] [nvarchar](max) NULL,
	[admittedward] [nvarchar](max) NULL,
	[admissionprogressnote] [nvarchar](max) NULL,
	[admissiondoctororder] [nvarchar](max) NULL,
	[admissionremarks] [nvarchar](max) NULL,
	[othermedicalhistory] [nvarchar](max) NULL,
	[allergies] [nvarchar](max) NULL,
	[signsymptoms] [nvarchar](max) NULL,
	[medicinetaken] [nvarchar](max) NULL,
	[chiefcomplaint] [nvarchar](max) NULL,
	[illnesshistory] [nvarchar](max) NULL,
	[findings] [nvarchar](max) NULL,
	[diagnosis] [nvarchar](max) NULL,
	[doctorsorder] [nvarchar](max) NULL,
	[dataType] [int] NOT NULL,
	[tempqueue] [smallint] NOT NULL,
	[pccConsultation] [smallint] NOT NULL,
	[opdconsent] [nvarchar](max) NULL,
	[opdconsent2] [nvarchar](max) NULL,
	[traigenurseonduty] [nvarchar](100) NULL,
	[isFollowUpConsultation] [smallint] NOT NULL,
	[isFreeConsltation] [smallint] NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[datemodified] [datetime] NULL,
	[FK_emdPatients] [bigint] NOT NULL,
	[servertransaction_id] [bigint] NOT NULL,
	[info_id] [bigint] NOT NULL,
	[served_id] [bigint] NOT NULL,
	[tmpAssignCounter_id] [bigint] NULL,
	[isEConsulta] [smallint] NOT NULL,
	[isHelee] [smallint] NOT NULL,
	[isDole] [smallint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[diagnosticrequests]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diagnosticrequests](
	[diagnostic_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[diagnostic] [nvarchar](max) NULL,
	[ItemDescription] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[opdconsent] [nvarchar](max) NULL,
	[opdconsent2] [nvarchar](max) NULL,
	[requestDate] [datetime] NOT NULL,
	[modifiedDate] [datetime] NULL,
	[doneDate] [datetime] NULL,
	[FK_emdPatients] [bigint] NOT NULL,
	[FK_Diagnostic_ID] [bigint] NULL,
	[FK_psPatRegisters] [bigint] NULL,
	[servertransaction_id] [bigint] NOT NULL,
	[info_id] [bigint] NULL,
	[vital_id] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctorsorderform]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctorsorderform](
	[form_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[hospitalno] [nvarchar](50) NULL,
	[filelocation] [varchar](100) NULL,
	[consultation_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ertriageform]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ertriageform](
	[form_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[caseno] [nvarchar](50) NULL,
	[bedno] [nvarchar](50) NULL,
	[isGCBER] [smallint] NOT NULL,
	[isRESPIER] [smallint] NOT NULL,
	[modeofarrival] [int] NOT NULL,
	[ambulance] [nvarchar](50) NULL,
	[timeofcall] [datetime] NOT NULL,
	[timeofdispatch] [datetime] NOT NULL,
	[levelofconsciousness] [int] NOT NULL,
	[Classification] [int] NULL,
	[timeofarrival] [datetime] NOT NULL,
	[timeendorsedrod] [datetime] NOT NULL,
	[timeseenrod] [datetime] NOT NULL,
	[timeendorsedunit] [datetime] NOT NULL,
	[patientcontactno] [nvarchar](50) NULL,
	[watchercontactno] [nvarchar](50) NULL,
	[patientreligion] [nvarchar](50) NULL,
	[painscale] [int] NULL,
	[cbg] [nvarchar](5) NULL,
	[travelhistory] [nvarchar](50) NULL,
	[vaccination1] [nvarchar](50) NULL,
	[vaccination2] [nvarchar](50) NULL,
	[vaccination3] [nvarchar](50) NULL,
	[traigenurseonduty] [nvarchar](100) NULL,
	[residentphysicianonduty] [nvarchar](100) NULL,
	[carriedoutby] [nvarchar](100) NULL,
	[filelocation] [varchar](100) NULL,
	[consultation_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[followupconsultation]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[followupconsultation](
	[ff_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[consultationdate] [datetime] NOT NULL,
	[consultationclinic] [varchar](100) NOT NULL,
	[consultation_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[healthcheckdata]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[healthcheckdata](
	[healthcheck_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[feverchills] [smallint] NOT NULL,
	[cough] [smallint] NOT NULL,
	[sorethroat] [smallint] NOT NULL,
	[diarrhea] [smallint] NOT NULL,
	[shortnessofbreathing] [smallint] NOT NULL,
	[ageusia] [smallint] NOT NULL,
	[anosmia] [smallint] NOT NULL,
	[colds] [smallint] NOT NULL,
	[closecontactconfirmed] [smallint] NOT NULL,
	[closecontactpersonexhibiting] [smallint] NOT NULL,
	[VisitPurpose] [nvarchar](100) NOT NULL,
	[dateofassesment] [datetime] NOT NULL,
	[allowedToEnter] [tinyint] NULL,
	[FK_emdPatients] [bigint] NOT NULL,
	[info_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nursenotes]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nursenotes](
	[form_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[hospitalno] [nvarchar](50) NULL,
	[focus] [nvarchar](50) NULL,
	[dataaction] [nvarchar](50) NULL,
	[filelocation] [varchar](100) NULL,
	[consultation_id] [bigint] NOT NULL,
	[fk_formid] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientExamSched]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientExamSched](
	[PK_SckedNo] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FK_psPatRegister] [bigint] NOT NULL,
	[PatientName] [varchar](150) NOT NULL,
	[FK_IwItemReq] [varchar](20) NULL,
	[ItemDesc] [varchar](max) NULL,
	[QtyReq] [numeric](3, 0) NULL,
	[QtyBalance] [numeric](3, 0) NULL,
	[Department] [numeric](10, 0) NULL,
	[DeptDesc] [varchar](150) NULL,
	[SkedDate] [date] NULL,
	[SkedTimeFrom] [varchar](10) NULL,
	[SkedTimeTo] [varchar](10) NULL,
	[DateDone] [datetime] NULL,
	[DateArrived] [datetime] NULL,
	[DeleteDate] [datetime] NULL,
	[PK_TRXNO] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[procedureconsent]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[procedureconsent](
	[form_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[watchergivenname] [nvarchar](50) NULL,
	[watchersurname] [nvarchar](50) NULL,
	[watcherage] [int] NOT NULL,
	[watcherrelation] [nvarchar](50) NULL,
	[procedures] [nvarchar](50) NULL,
	[explainedby] [nvarchar](50) NULL,
	[witnessname] [nvarchar](50) NULL,
	[witnessaddress] [nvarchar](100) NULL,
	[interpretername] [nvarchar](50) NULL,
	[interpreteraddress] [nvarchar](100) NULL,
	[filelocation] [varchar](100) NULL,
	[consultation_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[progressnotes]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[progressnotes](
	[item_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[datecreated] [datetime] NOT NULL,
	[progressnote] [nvarchar](max) NULL,
	[doctorsorder] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[consultation_id] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[queueingads]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[queueingads](
	[ads_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ads_name] [nvarchar](100) NOT NULL,
	[ads_locaton] [nvarchar](200) NOT NULL,
	[ads_type] [int] NOT NULL,
	[date_uploaded] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[refbrgy]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[refbrgy](
	[id] [int] NOT NULL,
	[brgyCode] [nvarchar](255) NULL,
	[brgyDesc] [nvarchar](max) NULL,
	[regCode] [nvarchar](255) NULL,
	[provCode] [nvarchar](255) NULL,
	[citymunCode] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[refcitymun]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[refcitymun](
	[id] [int] NOT NULL,
	[psgcCode] [nvarchar](255) NULL,
	[citymunDesc] [nvarchar](max) NULL,
	[regDesc] [nvarchar](255) NULL,
	[provCode] [nvarchar](255) NULL,
	[citymunCode] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[refprovince]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[refprovince](
	[id] [int] NOT NULL,
	[psgcCode] [nvarchar](255) NULL,
	[provDesc] [nvarchar](max) NULL,
	[regCode] [nvarchar](255) NULL,
	[provCode] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[refregion]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[refregion](
	[id] [int] NOT NULL,
	[psgcCode] [nvarchar](255) NULL,
	[regDesc] [nvarchar](max) NULL,
	[regCode] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[viewableads]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[viewableads](
	[vieableads_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[validity_date] [date] NOT NULL,
	[ads_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[administatoraccount]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[administatoraccount](
	[admin_id] [bigint] IDENTITY(2,1) NOT FOR REPLICATION NOT NULL,
	[adminfullname] [nvarchar](100) NOT NULL,
	[admindepartment] [nvarchar](100) NOT NULL,
	[adminusername] [nvarchar](50) NOT NULL,
	[adminpassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_administatoraccount_admin_id] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[counter]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[counter](
	[counter_id] [int] IDENTITY(27,1) NOT FOR REPLICATION NOT NULL,
	[department] [varchar](50) NOT NULL,
	[section] [varchar](100) NOT NULL,
	[servicedescription] [varchar](100) NOT NULL,
	[servicedescription2] [varchar](100) NULL,
	[counterPrefix] [varchar](5) NOT NULL,
	[countercode] [varchar](5) NOT NULL,
	[icon] [int] NULL,
	[isQueuingCounter] [smallint] NOT NULL,
	[autotransfer_diagnosticrequest] [tinyint] NOT NULL,
	[autotransfer_prescriptiobrequest] [tinyint] NOT NULL,
	[autotransfer_screening] [tinyint] NOT NULL,
	[autotransfer_payment] [smallint] NOT NULL,
	[autotransfer_gcber] [smallint] NOT NULL,
	[autotransfer_respiber] [smallint] NOT NULL,
	[autotransfer_ancillary] [smallint] NOT NULL,
	[counterType] [smallint] NOT NULL,
	[isResultCounter] [smallint] NOT NULL,
	[canCustomerName] [smallint] NOT NULL,
	[canPaymentMethod] [smallint] NOT NULL,
	[allowableTurnaroundTime] [numeric](20, 0) NOT NULL,
	[consultationView] [smallint] NOT NULL,
	[consultationAddEdit] [smallint] NOT NULL,
	[diagnosticView] [smallint] NOT NULL,
	[diagnosticAddEdit] [smallint] NOT NULL,
	[eprescirptionView] [smallint] NOT NULL,
	[eprescirptionAddEdit] [smallint] NOT NULL,
	[healthcheckView] [smallint] NOT NULL,
	[healthcheckAddEdit] [smallint] NOT NULL,
	[initialconsultation] [smallint] NOT NULL,
	[erconsultation] [smallint] NOT NULL,
	[syncDetail] [smallint] NOT NULL,
	[fk_counter_id] [int] NULL,
	[counterStepByStep] [int] NOT NULL,
	[generateScreening] [smallint] NOT NULL,
	[canEKonsulta] [smallint] NOT NULL,
	[canHelee] [smallint] NOT NULL,
 CONSTRAINT [PK_counter_counter_id] PRIMARY KEY CLUSTERED 
(
	[counter_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[customer]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[customer](
	[customer_id] [int] IDENTITY(13800,1) NOT FOR REPLICATION NOT NULL,
	[fullname] [varchar](100) NULL,
	[firstname] [varchar](100) NULL,
	[middlename] [varchar](100) NULL,
	[lastname] [varchar](100) NULL,
	[sex] [varchar](100) NULL,
	[birthdate] [date] NULL,
	[civilstatus] [varchar](100) NULL,
	[address] [varchar](100) NULL,
	[phonenumber] [varchar](100) NULL,
	[dateofvisit] [datetime2](0) NOT NULL,
	[FK_emdPatients] [bigint] NULL,
	[info_id] [bigint] NULL,
 CONSTRAINT [PK_customer_customer_id] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[customerassigncounter]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[customerassigncounter](
	[customerassigncounter_id] [int] IDENTITY(13744,1) NOT FOR REPLICATION NOT NULL,
	[counter_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[datetimequeued] [datetime2](0) NOT NULL,
	[priority] [int] NOT NULL,
	[forHelee] [smallint] NOT NULL,
	[result] [smallint] NOT NULL,
	[queuenumber] [int] NOT NULL,
	[paymentmethod] [numeric](18, 0) NOT NULL,
	[notes] [nvarchar](max) NULL,
	[notedepartment] [nvarchar](50) NULL,
	[notesection] [nvarchar](50) NULL,
	[showFlag] [smallint] NOT NULL,
 CONSTRAINT [PK_customerassigncounter_customerassigncounter_id] PRIMARY KEY CLUSTERED 
(
	[customerassigncounter_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[mghroomstatus]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[mghroomstatus](
	[mgh_id] [int] IDENTITY(648,1) NOT FOR REPLICATION NOT NULL,
	[RoomNo] [nvarchar](10) NOT NULL,
	[bedno] [nvarchar](10) NOT NULL,
	[station] [nvarchar](20) NOT NULL,
	[patient] [nvarchar](50) NOT NULL,
	[admitteddate] [datetime2](0) NULL,
	[mghdate] [datetime2](0) NULL,
	[registrystatus] [nvarchar](5) NOT NULL,
	[isoocupied] [smallint] NOT NULL,
	[status] [nvarchar](100) NOT NULL,
	[isFinished] [smallint] NOT NULL,
	[admission_id] [int] NOT NULL,
 CONSTRAINT [PK_mghroomstatus_mgh_id] PRIMARY KEY CLUSTERED 
(
	[mgh_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[servedcustomer]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[servedcustomer](
	[served_id] [bigint] IDENTITY(11325,1) NOT FOR REPLICATION NOT NULL,
	[servertransaction_id] [int] NOT NULL,
	[customerassigncounter_id] [int] NOT NULL,
	[datetimeservedstart] [datetime2](0) NULL,
	[datetimeservedend] [datetime2](0) NULL,
 CONSTRAINT [PK_servedcustomer_served_id] PRIMARY KEY CLUSTERED 
(
	[served_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[server]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[server](
	[server_id] [bigint] IDENTITY(98,1) NOT FOR REPLICATION NOT NULL,
	[employee_id] [varchar](100) NOT NULL,
	[fullname] [varchar](100) NOT NULL,
	[assigndepartment] [varchar](100) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[firstname] [varchar](50) NULL,
	[middlename] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[specializaton] [varchar](50) NULL,
	[ptr] [varchar](50) NULL,
	[prc] [varchar](50) NULL,
	[accountType] [int] NOT NULL,
	[physician_id] [varchar](100) NULL,
	[s2] [varchar](50) NULL,
	[digitalSignature] [varchar](max) NULL,
 CONSTRAINT [PK_server_server_id] PRIMARY KEY CLUSTERED 
(
	[server_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[serverassigncounter]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[serverassigncounter](
	[serverassigncounter_ID] [int] IDENTITY(277,1) NOT FOR REPLICATION NOT NULL,
	[server_id] [bigint] NOT NULL,
	[counter_id] [bigint] NOT NULL,
	[datecreated] [datetime2](0) NOT NULL,
	[isMain] [smallint] NOT NULL,
 CONSTRAINT [PK_serverassigncounter_serverassigncounter_ID] PRIMARY KEY CLUSTERED 
(
	[serverassigncounter_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[servercountershorcut]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[servercountershorcut](
	[servershorcut_id] [bigint] IDENTITY(19,1) NOT FOR REPLICATION NOT NULL,
	[server_id] [bigint] NOT NULL,
	[counter_id] [bigint] NOT NULL,
 CONSTRAINT [PK_servercountershorcut_servershorcut_id] PRIMARY KEY CLUSTERED 
(
	[servershorcut_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wmmcqms].[servertransaction]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wmmcqms].[servertransaction](
	[servertransaction_id] [int] IDENTITY(2074,1) NOT FOR REPLICATION NOT NULL,
	[serverassigncounter_id] [int] NOT NULL,
	[countername] [varchar](100) NOT NULL,
	[datetimelogin] [datetime2](0) NOT NULL,
	[datetimelogout] [datetime2](0) NULL,
 CONSTRAINT [PK_servertransaction_servertransaction_id] PRIMARY KEY CLUSTERED 
(
	[servertransaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bizbox_consultation] ADD  CONSTRAINT [DF_bizbox_consultation_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[bizbox_consultation] ADD  CONSTRAINT [DF_bizbox_consultation_isServed]  DEFAULT ((0)) FOR [isServed]
GO
ALTER TABLE [dbo].[bizbox_consultation] ADD  CONSTRAINT [DF_Table_1_served_id]  DEFAULT ((0)) FOR [servedcustomer_id]
GO
ALTER TABLE [dbo].[counterboard] ADD  CONSTRAINT [DF_Table_1_displayflag]  DEFAULT ((0)) FOR [displayctr]
GO
ALTER TABLE [dbo].[counterboard] ADD  CONSTRAINT [DF_counterboard_counter_id]  DEFAULT ((0)) FOR [counter_id]
GO
ALTER TABLE [dbo].[counterboardtransaction] ADD  CONSTRAINT [DF_counterboardtransaction_datetimelogged]  DEFAULT (getdate()) FOR [datetimelogged]
GO
ALTER TABLE [dbo].[customerinfo] ADD  CONSTRAINT [DF_customerinfo_picturelocation]  DEFAULT ('') FOR [picturelocation]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_productcode]  DEFAULT ((0)) FOR [productcode]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_atbedtime]  DEFAULT ((0)) FOR [atbedtime]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_daysIntake]  DEFAULT ((0)) FOR [daysIntake]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_requestdate]  DEFAULT (getdate()) FOR [requestdate]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_vital_id]  DEFAULT ((0)) FOR [vital_id]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_isS2_1]  DEFAULT ((0)) FOR [isS2]
GO
ALTER TABLE [dbo].[customerprescription] ADD  CONSTRAINT [DF_customerprescription_ctr]  DEFAULT ((0)) FOR [ctr]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_hypertension]  DEFAULT ((0)) FOR [hypertension]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_]  DEFAULT ((0)) FOR [diabetes]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_asthma]  DEFAULT ((0)) FOR [asthma]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_hearthdisease]  DEFAULT ((0)) FOR [hearthdisease]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_arthritis]  DEFAULT ((0)) FOR [arthritis]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_cancer]  DEFAULT ((0)) FOR [cancer]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_tuberculosis]  DEFAULT ((0)) FOR [tuberculosis]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_stroke]  DEFAULT ((0)) FOR [stroke]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_copd]  DEFAULT ((0)) FOR [copd]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_copd1]  DEFAULT ((0)) FOR [transferredreferred]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_transferredreferred1_1]  DEFAULT ((0)) FOR [refusedadmission]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_transferredreferred1]  DEFAULT ((0)) FOR [erdeath]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_erdeath1]  DEFAULT ((0)) FOR [discharged]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_discharged1]  DEFAULT ((0)) FOR [forfollowup]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_forfollowup1]  DEFAULT ((0)) FOR [absconed]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_absconed1]  DEFAULT ((0)) FOR [hamadam]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_hamadam1]  DEFAULT ((0)) FOR [doa]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_hamadam1_1]  DEFAULT ((0)) FOR [admitted]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_dataType]  DEFAULT ((0)) FOR [dataType]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_tempqueue]  DEFAULT ((0)) FOR [tempqueue]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_initialConsultation]  DEFAULT ((0)) FOR [pccConsultation]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_isFollowUpConsultation]  DEFAULT ((0)) FOR [isFollowUpConsultation]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_isFreeConsltation]  DEFAULT ((0)) FOR [isFreeConsltation]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_served_id]  DEFAULT ((0)) FOR [served_id]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_isEConsulta]  DEFAULT ((0)) FOR [isEConsulta]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_isEConsulta1]  DEFAULT ((0)) FOR [isHelee]
GO
ALTER TABLE [dbo].[customervitals] ADD  CONSTRAINT [DF_customervitals_isHelee1]  DEFAULT ((0)) FOR [isDole]
GO
ALTER TABLE [dbo].[diagnosticrequests] ADD  CONSTRAINT [DF_diagnosticrequests_requestDate]  DEFAULT (getdate()) FOR [requestDate]
GO
ALTER TABLE [dbo].[diagnosticrequests] ADD  CONSTRAINT [DF_diagnosticrequests_vital_id]  DEFAULT ((0)) FOR [vital_id]
GO
ALTER TABLE [dbo].[doctorsorderform] ADD  CONSTRAINT [DF_doctorsorderform_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_isGCBER]  DEFAULT ((0)) FOR [isGCBER]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_isRESPIER]  DEFAULT ((0)) FOR [isRESPIER]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_modeofarrival]  DEFAULT ((0)) FOR [modeofarrival]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_timeofcall]  DEFAULT (getdate()) FOR [timeofcall]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_timeofdispatch]  DEFAULT (getdate()) FOR [timeofdispatch]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_levelofconsciousness]  DEFAULT ((0)) FOR [levelofconsciousness]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_timeofarrival]  DEFAULT (getdate()) FOR [timeofarrival]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_timeendorsedrod]  DEFAULT (getdate()) FOR [timeendorsedrod]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_timeseenrod]  DEFAULT (getdate()) FOR [timeseenrod]
GO
ALTER TABLE [dbo].[ertriageform] ADD  CONSTRAINT [DF_ertriageform_timeendorsedunit]  DEFAULT (getdate()) FOR [timeendorsedunit]
GO
ALTER TABLE [dbo].[healthcheckdata] ADD  CONSTRAINT [DF_healthcheckdata_VisitPurpose]  DEFAULT ('') FOR [VisitPurpose]
GO
ALTER TABLE [dbo].[healthcheckdata] ADD  CONSTRAINT [DF_healthcheckdata_dateofassesment]  DEFAULT (getdate()) FOR [dateofassesment]
GO
ALTER TABLE [dbo].[nursenotes] ADD  CONSTRAINT [DF_nursenotes_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[nursenotes] ADD  CONSTRAINT [DF_nursenotes_consultation_id]  DEFAULT ((0)) FOR [consultation_id]
GO
ALTER TABLE [dbo].[procedureconsent] ADD  CONSTRAINT [DF_procedureconsent_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[procedureconsent] ADD  CONSTRAINT [DF_procedureconsent_watcherAge]  DEFAULT ((0)) FOR [watcherage]
GO
ALTER TABLE [dbo].[procedureconsent] ADD  CONSTRAINT [DF_procedureconsent_consultation_id]  DEFAULT ((0)) FOR [consultation_id]
GO
ALTER TABLE [dbo].[progressnotes] ADD  CONSTRAINT [DF_progressnotes_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[progressnotes] ADD  CONSTRAINT [DF_progressnotes_consultation_id]  DEFAULT ((0)) FOR [consultation_id]
GO
ALTER TABLE [dbo].[queueingads] ADD  CONSTRAINT [DF_queueingads_date_uploaded]  DEFAULT (getdate()) FOR [date_uploaded]
GO
ALTER TABLE [dbo].[viewableads] ADD  CONSTRAINT [DF_viewableads_validity_date]  DEFAULT (getdate()) FOR [validity_date]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF__counter__counter__239E4DCF]  DEFAULT (N'12345') FOR [countercode]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF__counter__icon__24927208]  DEFAULT ((0)) FOR [icon]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF__counter__isQueui__25869641]  DEFAULT ((1)) FOR [isQueuingCounter]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_diagnosticrequest]  DEFAULT ((0)) FOR [autotransfer_diagnosticrequest]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_prescriptiobrequest]  DEFAULT ((0)) FOR [autotransfer_prescriptiobrequest]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_screening]  DEFAULT ((0)) FOR [autotransfer_screening]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_billing]  DEFAULT ((0)) FOR [autotransfer_payment]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_payment1]  DEFAULT ((0)) FOR [autotransfer_gcber]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_gcber1]  DEFAULT ((0)) FOR [autotransfer_respiber]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_autotransfer_labextration]  DEFAULT ((0)) FOR [autotransfer_ancillary]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_counterType]  DEFAULT ((0)) FOR [counterType]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF__counter__isResul__267ABA7A]  DEFAULT ((0)) FOR [isResultCounter]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_canPatientName]  DEFAULT ((0)) FOR [canCustomerName]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_canPaymentMethod]  DEFAULT ((0)) FOR [canPaymentMethod]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_allowableTurnaroundTime]  DEFAULT ((10)) FOR [allowableTurnaroundTime]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_consultation]  DEFAULT ((0)) FOR [consultationView]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_consultationAdd]  DEFAULT ((0)) FOR [consultationAddEdit]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_eprescirptionView1]  DEFAULT ((0)) FOR [diagnosticView]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_eprescirptionAddEdit1]  DEFAULT ((0)) FOR [diagnosticAddEdit]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_eprescirptionView]  DEFAULT ((0)) FOR [eprescirptionView]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_eprescirptionAddEdit]  DEFAULT ((0)) FOR [eprescirptionAddEdit]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_healthcheckView]  DEFAULT ((0)) FOR [healthcheckView]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_healthcheckAddEdit]  DEFAULT ((0)) FOR [healthcheckAddEdit]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_]  DEFAULT ((0)) FOR [initialconsultation]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_initialconsultation1]  DEFAULT ((0)) FOR [erconsultation]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_syncDetail]  DEFAULT ((0)) FOR [syncDetail]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_counterStepByStep]  DEFAULT ((0)) FOR [counterStepByStep]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_generateScreening]  DEFAULT ((0)) FOR [generateScreening]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_canEKonsulta]  DEFAULT ((0)) FOR [canEKonsulta]
GO
ALTER TABLE [wmmcqms].[counter] ADD  CONSTRAINT [DF_counter_canHelee]  DEFAULT ((0)) FOR [canHelee]
GO
ALTER TABLE [wmmcqms].[customer] ADD  CONSTRAINT [DF__customer__fullna__276EDEB3]  DEFAULT (NULL) FOR [fullname]
GO
ALTER TABLE [wmmcqms].[customer] ADD  CONSTRAINT [DF__customer__addres__286302EC]  DEFAULT (NULL) FOR [address]
GO
ALTER TABLE [wmmcqms].[customer] ADD  CONSTRAINT [DF__customer__phonen__29572725]  DEFAULT (NULL) FOR [phonenumber]
GO
ALTER TABLE [wmmcqms].[customer] ADD  CONSTRAINT [DF__customer__dateof__2A4B4B5E]  DEFAULT (getdate()) FOR [dateofvisit]
GO
ALTER TABLE [wmmcqms].[customerassigncounter] ADD  CONSTRAINT [DF__customera__datet__2B3F6F97]  DEFAULT (getdate()) FOR [datetimequeued]
GO
ALTER TABLE [wmmcqms].[customerassigncounter] ADD  CONSTRAINT [DF__customera__prior__2C3393D0]  DEFAULT ((0)) FOR [priority]
GO
ALTER TABLE [wmmcqms].[customerassigncounter] ADD  CONSTRAINT [DF_customerassigncounter_forHelee]  DEFAULT ((0)) FOR [forHelee]
GO
ALTER TABLE [wmmcqms].[customerassigncounter] ADD  CONSTRAINT [DF__customera__resul__2D27B809]  DEFAULT ((0)) FOR [result]
GO
ALTER TABLE [wmmcqms].[customerassigncounter] ADD  CONSTRAINT [DF_customerassigncounter_paymentmethod]  DEFAULT ((0)) FOR [paymentmethod]
GO
ALTER TABLE [wmmcqms].[customerassigncounter] ADD  CONSTRAINT [DF_customerassigncounter_showFlag]  DEFAULT ((1)) FOR [showFlag]
GO
ALTER TABLE [wmmcqms].[mghroomstatus] ADD  CONSTRAINT [DF__mghroomst__admit__2E1BDC42]  DEFAULT (getdate()) FOR [admitteddate]
GO
ALTER TABLE [wmmcqms].[mghroomstatus] ADD  CONSTRAINT [DF__mghroomst__mghda__2F10007B]  DEFAULT (getdate()) FOR [mghdate]
GO
ALTER TABLE [wmmcqms].[mghroomstatus] ADD  CONSTRAINT [DF__mghroomst__isFin__300424B4]  DEFAULT ((0)) FOR [isFinished]
GO
ALTER TABLE [wmmcqms].[servedcustomer] ADD  CONSTRAINT [DF__servedcus__datet__30F848ED]  DEFAULT (getdate()) FOR [datetimeservedstart]
GO
ALTER TABLE [wmmcqms].[servedcustomer] ADD  CONSTRAINT [DF__servedcus__datet__31EC6D26]  DEFAULT (NULL) FOR [datetimeservedend]
GO
ALTER TABLE [wmmcqms].[server] ADD  CONSTRAINT [DF_server_accountType]  DEFAULT ((0)) FOR [accountType]
GO
ALTER TABLE [wmmcqms].[serverassigncounter] ADD  CONSTRAINT [DF__serverass__datec__32E0915F]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [wmmcqms].[serverassigncounter] ADD  CONSTRAINT [DF__serverass__isMai__33D4B598]  DEFAULT ((0)) FOR [isMain]
GO
ALTER TABLE [wmmcqms].[servertransaction] ADD  CONSTRAINT [DF__servertra__datet__34C8D9D1]  DEFAULT (getdate()) FOR [datetimelogin]
GO
ALTER TABLE [wmmcqms].[servertransaction] ADD  CONSTRAINT [DF__servertra__datet__35BCFE0A]  DEFAULT (NULL) FOR [datetimelogout]
GO
/****** Object:  StoredProcedure [wmmcqms].[GetCertainCounterQueueBoard]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
*   SSMA informational messages:
*   M2SS0003: The following SQL clause was ignored during conversion:
*   DEFINER = `root`@`localhost`.
*/

/*
*   SSMA informational messages:
*   M2SS0003: The following SQL clause was ignored during conversion:
*   NO SQL.
*/

CREATE PROCEDURE [wmmcqms].[GetCertainCounterQueueBoard]  
   @ID bigint
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT 
         x.servertransaction_id, 
         x.serverassigncounter_id, 
         x.countername, 
         x.datetimelogin, 
         x.datetimelogout, 
         d.serverassigncounter_ID, 
         d.server_id, 
         d.counter_id, 
         d.datecreated, 
         d.isMain, 
         a.served_id, 
         a.servertransaction_id, 
         a.customerassigncounter_id, 
         a.datetimeservedstart, 
         a.datetimeservedend, 
         b.customerassigncounter_id, 
         b.counter_id, 
         b.customer_id, 
         b.datetimequeued, 
         b.priority, 
         b.result, 
         b.queuenumber, 
         c.counter_id, 
         c.department, 
         c.section, 
         c.servicedescription, 
         c.counterPrefix, 
         c.countercode, 
         c.icon, 
         c.isQueuingCounter, 
         c.isResultCounter
      FROM 
         wmmcqms.servedcustomer  AS a 
            INNER JOIN wmmcqms.customerassigncounter  AS b 
            ON a.customerassigncounter_id = b.customerassigncounter_id AND b.datetimequeued = CAST(getdate() AS DATE) 
            INNER JOIN wmmcqms.counter  AS c 
            ON b.counter_id = c.counter_id 
            RIGHT JOIN wmmcqms.servertransaction  AS x 
            ON 
               x.servertransaction_id = a.servertransaction_id AND 
               a.datetimeservedend IS NULL AND 
               a.datetimeservedstart IS NOT NULL 
            INNER JOIN wmmcqms.serverassigncounter  AS d 
            ON x.serverassigncounter_id = d.serverassigncounter_ID AND d.counter_id = @ID
      WHERE x.datetimelogin = CAST(getdate() AS DATE) AND x.datetimelogout IS NULL

   END
GO
/****** Object:  StoredProcedure [wmmcqms].[getCouterServingNextNumber]    Script Date: 4/3/2024 10:02:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
*   SSMA informational messages:
*   M2SS0003: The following SQL clause was ignored during conversion:
*   DEFINER = `root`@`localhost`.
*/

/*
*   SSMA informational messages:
*   M2SS0003: The following SQL clause was ignored during conversion:
*   NO SQL.
*/

CREATE PROCEDURE [wmmcqms].[getCouterServingNextNumber]  
   @ID bigint
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      /*
      *   SSMA warning messages:
      *   M2SS0104: Non aggregated column QUEUENUMBER is aggregated with Min(..) in Select, Orderby and Having clauses.
      */

      SELECT min(a.customerassigncounter_id) AS customerassigncounter_id, min(a.queuenumber) AS queuenumber
      FROM wmmcqms.customerassigncounter  AS a
      WHERE (a.datetimequeued = CAST(getdate() AS DATE) AND a.counter_id = @ID) AND (a.customerassigncounter_id NOT IN 
         (
            SELECT b.customerassigncounter_id
            FROM wmmcqms.servedcustomer  AS b
         ))

   END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.GetCertainCounterQueueBoard' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'PROCEDURE',@level1name=N'GetCertainCounterQueueBoard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.getCouterServingNextNumber' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'PROCEDURE',@level1name=N'getCouterServingNextNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.administatoraccount' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'administatoraccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.counter' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'counter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.customer' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.customerassigncounter' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'customerassigncounter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.mghroomstatus' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'mghroomstatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.servedcustomer' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'servedcustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.server' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.serverassigncounter' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'serverassigncounter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.servercountershorcut' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'servercountershorcut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'wmmcqms.servertransaction' , @level0type=N'SCHEMA',@level0name=N'wmmcqms', @level1type=N'TABLE',@level1name=N'servertransaction'
GO
USE [master]
GO
ALTER DATABASE [hhmhqueueingdb] SET  READ_WRITE 
GO
