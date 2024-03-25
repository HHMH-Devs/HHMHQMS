Imports System.Data
Imports System.Data.SqlClient
Public Class CustomerConsultationController
    Public Function GetBizboxCustomerConsultations(ByVal infoID As Long, ByVal fkEmdPatient As Long) As List(Of Bizbox_Consultation)
        Dim list As List(Of Bizbox_Consultation)
        Try
            Dim cmd As New SqlCommand
            Dim str As String = ""
            If (fkEmdPatient > 0) Then
                str = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = ("SELECT
                                a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',
                                d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',
                                f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                FROM [dbo].[bizbox_consultation] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE (a.info_id = @inid " & str & ") ORDER BY a.consultation_id  DESC;")
            cmd.Parameters.AddWithValue("@inid", infoID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim consultations As New List(Of Bizbox_Consultation)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_Consultation
                    item.ID = (row("a_consultation_id"))
                    item.DateCreated = (row("a_datecreated"))
                    item.DateModified = If(Not Information.IsDBNull(row("a_datemodified")), row("a_datemodified"), Nothing)
                    item.OPDConsent1 = (row("a_opdconsent1"))
                    item.OPDConsent2 = (row("a_opdconsent2"))
                    item.isServed = (row("a_isServed"))
                    item.ForInitialConsultation_ServerAssignCounter_ID = (row("a_forinitialconsult_serverassigncounter_ID"))
                    item.FK_psPatRegisters = (row("a_FK_psPatRegisters"))
                    item.FK_emdPatients = (row("a_FK_emdPatients"))
                    item.Info_ID = (row("a_info_id"))
                    item.ServerTransaction_ID = (row("a_servertransaction_id"))
                    item.ServedCustomerID = (row("a_servedcustomer_id"))
                    item.ServerTransaction = New ServerTransaction
                    item.ServerTransaction.ServerTransaction_ID = (row("e_servertransaction_id"))
                    item.ServerTransaction.ServerAssignCounter_ID = (row("e_serverassigncounter_id"))
                    item.ServerTransaction.CounterName = (row("e_countername"))
                    item.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    item.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (row("f_serverassigncounter_ID"))
                    item.ServerTransaction.ServerAssignCounter.Server_ID = (row("f_server_id"))
                    item.ServerTransaction.ServerAssignCounter.Counter_ID = (row("f_counter_id"))
                    item.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    item.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (row("h_counter_id"))
                    item.ServerTransaction.ServerAssignCounter.Counter.Department = (row("h_department"))
                    item.ServerTransaction.ServerAssignCounter.Counter.Section = (row("h_section"))
                    item.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (row("h_servicedescription"))
                    item.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (row("h_counterPrefix"))
                    item.ServerTransaction.ServerAssignCounter.Counter.Icon = (row("h_icon"))
                    item.ServerTransaction.ServerAssignCounter.Counter.consultationView = (row("h_consultationView"))
                    item.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (row("h_consultationAddEdit"))
                    item.ServerTransaction.ServerAssignCounter.Server = New Server
                    item.ServerTransaction.ServerAssignCounter.Server.Server_ID = (row("g_server_id"))
                    item.ServerTransaction.ServerAssignCounter.Server.FullName = (row("g_fullname"))
                    item.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (row("g_assigndepartment"))
                    item.ServerTransaction.ServerAssignCounter.Server.PRC = (row("g_prc"))
                    item.ServerTransaction.ServerAssignCounter.Server.PTR = (row("g_ptr"))
                    item.ServerTransaction.ServerAssignCounter.Server.S2No = (row("g_s2"))
                    item.ServedCustomer = New ServedCustomer
                    item.ServedCustomer.ServedCustomer_ID = (row("b_served_id"))
                    item.ServedCustomer.ServerTransaction_ID = (row("b_servertransaction_id"))
                    item.ServedCustomer.CustomerAssginCounter_ID = (row("b_customerassigncounter_id"))
                    item.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull(row("b_datetimeservedstart")), row("b_datetimeservedstart"), Nothing)
                    item.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull(row("b_datetimeservedend")), row("b_datetimeservedend"), Nothing)
                    item.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    item.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (row("c_customerassigncounter_id"))
                    item.ServedCustomer.CustomerAssignCounter.Counter_ID = (row("c_counter_id"))
                    item.ServedCustomer.CustomerAssignCounter.Customer_ID = (row("c_customer_id"))
                    item.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (row("c_datetimequeued"))
                    item.ServedCustomer.CustomerAssignCounter.Priority = (row("c_priority"))
                    item.ServedCustomer.CustomerAssignCounter.Result = (row("c_result"))
                    item.ServedCustomer.CustomerAssignCounter.QueueNumber = (row("c_queuenumber"))
                    item.ServedCustomer.CustomerAssignCounter.PaymentMethod = (row("c_paymentmethod"))
                    item.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull(row("c_notes")), row("c_notes"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull(row("c_notedepartment")), row("c_notedepartment"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull(row("c_notesection")), row("c_notesection"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    item.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (row("d_customer_id"))
                    item.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull(row("d_fullname")), row("d_fullname"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull(row("d_firstname")), row("d_firstname"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull(row("d_middlename")), row("d_middlename"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull(row("d_lastname")), row("d_lastname"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull(row("d_sex")), row("d_sex"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull(row("d_birthdate")), row("d_birthdate"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull(row("d_civilstatus")), row("d_civilstatus"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull(row("d_address")), row("d_address"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull(row("d_phonenumber")), row("d_phonenumber"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (row("d_dateofvisit"))
                    item.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull(row("d_FK_emdPatients")), row("d_FK_emdPatients"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull(row("d_info_id")), row("d_info_id"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (row("i_info_id"))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull(row("i_firstname")), row("i_firstname"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull(row("i_middlename")), row("i_middlename"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull(row("i_middlename")), row("i_middlename"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull(row("i_sex")), row("i_sex"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull(row("i_birthdate")), row("i_birthdate"), Nothing))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull(row("i_civilstatus")), row("i_civilstatus"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull(row("i_street")), row("i_street"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull(row("i_barangay")), row("i_barangay"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull(row("i_city")), row("i_city"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull(row("i_phonenumber")), row("i_phonenumber"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull(row("i_nationality")), row("i_nationality"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull(row("i_picturelocation")), row("i_picturelocation"), ""))
                    item.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull(row("i_FK_emdPatients")), row("i_FK_emdPatients"), Nothing))
                    item.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                    item.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (row("j_serverassigncounter_ID"))
                    item.ForInitialConsultation_ServerAssignCounter.Server_ID = (row("j_server_id"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter_ID = (row("j_counter_id"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                    item.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (row("l_counter_id"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.Department = (row("l_department"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.Section = (row("l_section"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (row("l_servicedescription"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (row("l_counterPrefix"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (row("l_icon"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (row("l_consultationView"))
                    item.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (row("l_consultationAddEdit"))
                    item.ForInitialConsultation_ServerAssignCounter.Server = New Server
                    item.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (row("k_server_id"))
                    item.ForInitialConsultation_ServerAssignCounter.Server.FullName = (row("k_fullname"))
                    item.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (row("k_assigndepartment"))
                    item.ForInitialConsultation_ServerAssignCounter.Server.PRC = (row("k_prc"))
                    item.ForInitialConsultation_ServerAssignCounter.Server.PTR = (row("k_ptr"))
                    item.ForInitialConsultation_ServerAssignCounter.Server.S2No = (row("k_s2"))
                    item.BizboxRegistration = New BizboxAPI().GetCertainPatientRegistration3(item.FK_psPatRegisters, item.ForInitialConsultation_ServerAssignCounter.Server.PRC)
                    consultations.Add(item)
                Next
                Return consultations
            End If
            list = Nothing
        Catch exception As Exception
            Return Nothing
        End Try
        Return list
    End Function

    Public Function GetLatestPatientBizboxConsultation(ByVal patient As ServedCustomer) As Bizbox_Consultation
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT 
                                a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',
                                d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',
                                f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee' 
                                FROM [dbo].[bizbox_consultation] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE a.[consultation_id] = (SELECT MAX([consultation_id]) FROM [bizbox_consultation] as x WHERE  x.[servedcustomer_id] = @ID);"
            }
            cmd.Parameters.AddWithValue("@ID", patient.ServedCustomer_ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If Not Information.IsNothing(data) Then
                If Not (data.Rows.Count > 0) Then
                    Dim cmd2 As New SqlCommand With {
                        .CommandText = "SELECT * FROM [bizbox_consultation] WHERE isServed = 0 AND [consultation_id] = (SELECT MAX([consultation_id]) FROM [bizbox_consultation] as f WHERE f.isServed = 0 AND CONVERT(DATE, f.datecreated) = CONVERT(DATE, GETDATE()) AND [info_id] = @ID)"
                    }
                    cmd2.Parameters.AddWithValue("@ID", patient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                    data = WMMCQMSConfig.fetchData(cmd2).Tables(0)
                    If (Not Information.IsNothing(data) AndAlso (data.Rows.Count > 0)) Then
                        Dim id As Long = data.Rows(0)("consultation_id")
                        cmd = New SqlCommand With {
                            .CommandText = "SELECT
                                            a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                            b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                            c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                            e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',
                                            e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',
                                            f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                            g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                            h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                            i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                            j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                            k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                            l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                            FROM [dbo].[bizbox_consultation] as a
                                            JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                            JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                            JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                            JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                            JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                            JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                            JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                            JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                            JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                            JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                            JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                            WHERE [consultation_id] = @ID;"
                        }
                        cmd.Parameters.AddWithValue("@ID", id)
                        data = WMMCQMSConfig.fetchData(cmd).Tables(0)
                        If Information.IsNothing(data) Then
                            Return Nothing
                        End If
                        If Not (data.Rows.Count > 0) Then
                            Return Nothing
                        End If
                    End If
                End If
                If (data.Rows.Count > 0) Then
                    Dim id As Long = data.Rows(0)("a_consultation_id")
                    Dim cmd3 As New SqlCommand With {
                        .CommandText = "UPDATE [dbo].[bizbox_consultation] SET [datemodified] = GETDATE() ,[isServed] = 1 ,[servertransaction_id] = @stid ,[servedcustomer_id] = @sid WHERE consultation_id = @ID"
                    }
                    cmd3.Parameters.AddWithValue("@stid", If((patient.ServerTransaction_ID > 0), patient.ServerTransaction_ID, patient.ServerTransaction.ServerTransaction_ID))
                    cmd3.Parameters.AddWithValue("@sid", patient.ServedCustomer_ID)
                    cmd3.Parameters.AddWithValue("@ID", id)
                    If WMMCQMSConfig.excecuteCommand(cmd3) Then
                        Dim consultation As New Bizbox_Consultation
                        consultation.ID = (data.Rows(0)("a_consultation_id"))
                        consultation.DateCreated = (data.Rows(0)("a_datecreated"))
                        consultation.DateModified = If(Not Information.IsDBNull(data.Rows(0)("a_datemodified")), data.Rows(0)("a_datemodified"), Nothing)
                        consultation.OPDConsent1 = (data.Rows(0)("a_opdconsent1"))
                        consultation.OPDConsent2 = (data.Rows(0)("a_opdconsent2"))
                        consultation.isServed = (data.Rows(0)("a_isServed"))
                        consultation.ForInitialConsultation_ServerAssignCounter_ID = (data.Rows(0)("a_forinitialconsult_serverassigncounter_ID"))
                        consultation.FK_psPatRegisters = (data.Rows(0)("a_FK_psPatRegisters"))
                        consultation.FK_emdPatients = (data.Rows(0)("a_FK_emdPatients"))
                        consultation.Info_ID = (data.Rows(0)("a_info_id"))
                        consultation.ServerTransaction_ID = (data.Rows(0)("a_servertransaction_id"))
                        consultation.ServedCustomerID = (data.Rows(0)("a_servedcustomer_id"))
                        consultation.ServerTransaction = New ServerTransaction
                        consultation.ServerTransaction.ServerTransaction_ID = (data.Rows(0)("e_servertransaction_id"))
                        consultation.ServerTransaction.ServerAssignCounter_ID = (data.Rows(0)("e_serverassigncounter_id"))
                        consultation.ServerTransaction.CounterName = (data.Rows(0)("e_countername"))
                        consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("f_serverassigncounter_ID"))
                        consultation.ServerTransaction.ServerAssignCounter.Server_ID = (data.Rows(0)("f_server_id"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter_ID = (data.Rows(0)("f_counter_id"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                        consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("h_counter_id"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.Department = (data.Rows(0)("h_department"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.Section = (data.Rows(0)("h_section"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("h_servicedescription"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("h_counterPrefix"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = (data.Rows(0)("h_icon"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = (data.Rows(0)("h_consultationView"))
                        consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("h_consultationAddEdit"))
                        consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                        consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = (data.Rows(0)("g_server_id"))
                        consultation.ServerTransaction.ServerAssignCounter.Server.FullName = (data.Rows(0)("g_fullname"))
                        consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("g_assigndepartment"))
                        consultation.ServerTransaction.ServerAssignCounter.Server.PRC = (data.Rows(0)("g_prc"))
                        consultation.ServerTransaction.ServerAssignCounter.Server.PTR = (data.Rows(0)("g_ptr"))
                        consultation.ServerTransaction.ServerAssignCounter.Server.S2No = (data.Rows(0)("g_s2"))
                        consultation.ServedCustomer = New ServedCustomer
                        consultation.ServedCustomer.ServedCustomer_ID = (data.Rows(0)("b_served_id"))
                        consultation.ServedCustomer.ServerTransaction_ID = (data.Rows(0)("b_servertransaction_id"))
                        consultation.ServedCustomer.CustomerAssginCounter_ID = (data.Rows(0)("b_customerassigncounter_id"))
                        consultation.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull(data.Rows(0)("b_datetimeservedstart")), data.Rows(0)("b_datetimeservedstart"), Nothing)
                        consultation.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull(data.Rows(0)("b_datetimeservedend")), data.Rows(0)("b_datetimeservedend"), Nothing)
                        consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                        consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (data.Rows(0)("c_customerassigncounter_id"))
                        consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = (data.Rows(0)("c_counter_id"))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = (data.Rows(0)("c_customer_id"))
                        consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (data.Rows(0)("c_datetimequeued"))
                        consultation.ServedCustomer.CustomerAssignCounter.Priority = (data.Rows(0)("c_priority"))
                        consultation.ServedCustomer.CustomerAssignCounter.Result = (data.Rows(0)("c_result"))
                        consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = (data.Rows(0)("c_queuenumber"))
                        consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = (data.Rows(0)("c_paymentmethod"))
                        consultation.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull((data.Rows(0)("c_notes"))), data.Rows(0)("c_notes"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull((data.Rows(0)("c_notedepartment"))), data.Rows(0)("c_notedepartment"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull((data.Rows(0)("c_notesection"))), data.Rows(0)("c_notesection"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (data.Rows(0)("d_customer_id"))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull((data.Rows(0)("d_fullname"))), data.Rows(0)("d_fullname"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("d_firstname"))), data.Rows(0)("d_firstname"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull((data.Rows(0)("d_middlename"))), data.Rows(0)("d_middlename"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull((data.Rows(0)("d_lastname"))), data.Rows(0)("d_lastname"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull((data.Rows(0)("d_sex"))), data.Rows(0)("d_sex"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull((data.Rows(0)("d_birthdate"))), data.Rows(0)("d_birthdate"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("d_civilstatus"))), data.Rows(0)("d_civilstatus"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull((data.Rows(0)("d_address"))), data.Rows(0)("d_address"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("d_phonenumber"))), data.Rows(0)("d_phonenumber"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (data.Rows(0)("d_dateofvisit"))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("d_FK_emdPatients"))), data.Rows(0)("d_FK_emdPatients"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull((data.Rows(0)("d_info_id"))), data.Rows(0)("d_info_id"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (data.Rows(0)("i_info_id"))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("i_firstname"))), data.Rows(0)("i_firstname"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull((data.Rows(0)("i_sex"))), data.Rows(0)("i_sex"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull((data.Rows(0)("i_birthdate"))), data.Rows(0)("i_birthdate"), Nothing))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("i_civilstatus"))), data.Rows(0)("i_civilstatus"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull((data.Rows(0)("i_street"))), data.Rows(0)("i_street"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull((data.Rows(0)("i_barangay"))), data.Rows(0)("i_barangay"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull((data.Rows(0)("i_city"))), data.Rows(0)("i_city"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("i_phonenumber"))), data.Rows(0)("i_phonenumber"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull((data.Rows(0)("i_nationality"))), data.Rows(0)("i_nationality"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull((data.Rows(0)("i_picturelocation"))), data.Rows(0)("i_picturelocation"), ""))
                        consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("i_FK_emdPatients"))), data.Rows(0)("i_FK_emdPatients"), Nothing))
                        consultation.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                        consultation.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("j_serverassigncounter_ID"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server_ID = (data.Rows(0)("j_server_id"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter_ID = (data.Rows(0)("j_counter_id"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("l_counter_id"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.Department = (data.Rows(0)("l_department"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.Section = (data.Rows(0)("l_section"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("l_servicedescription"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("l_counterPrefix"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (data.Rows(0)("l_icon"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (data.Rows(0)("l_consultationView"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("l_consultationAddEdit"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server = New Server
                        consultation.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (data.Rows(0)("k_server_id"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server.FullName = (data.Rows(0)("k_fullname"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("k_assigndepartment"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC = (data.Rows(0)("k_prc"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server.PTR = (data.Rows(0)("k_ptr"))
                        consultation.ForInitialConsultation_ServerAssignCounter.Server.S2No = (data.Rows(0)("k_s2"))
                        consultation.BizboxRegistration = New BizboxAPI().GetCertainPatientRegistration3(consultation.FK_psPatRegisters, consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC)
                        Return consultation
                    End If
                End If
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function DeleteBizboxConsultation(ByVal ID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "DELETE FROM [dbo].[bizbox_consultation] WHERE [isServed] = 0 AND [consultation_id] = @ID"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Return WMMCQMSConfig.excecuteCommand(cmd)
        Catch exception1 As Exception
            Return False
        End Try
    End Function

    Public Function SaveBizboxInitialConsultation(ByVal consultation As Bizbox_Consultation) As Boolean
        Try
            Dim cmd As New SqlCommand
            If (consultation.ID > 0) Then
                cmd.CommandText = "UPDATE [dbo].[bizbox_consultation] SET [datemodified] = GETDATE(),[opdconsent1] = @opdcs1,[opdconsent2] = @opdcs2,[forinitialconsult_serverassigncounter_ID] = @forinit_svrasnctr_ID,[FK_psPatRegisters] = @FK_psPat,[FK_emdPatients] = @FK_emd,[info_id] = @inf_id,[servertransaction_id] = @svrtrns_id,[servedcustomer_id] = @svdcust_id WHERE [consultation_id] = @ID"
                cmd.Parameters.AddWithValue("@ID", consultation.ID)
            Else
                cmd.CommandText = "INSERT INTO [dbo].[bizbox_consultation] ([opdconsent1],[opdconsent2],[forinitialconsult_serverassigncounter_ID],[FK_psPatRegisters],[FK_emdPatients],[info_id],[servertransaction_id],[servedcustomer_id]) VALUES (@opdcs1,@opdcs2,@forinit_svrasnctr_ID,@FK_psPat,@FK_emd,@inf_id,@svrtrns_id,@svdcust_id)"
            End If
            cmd.Parameters.AddWithValue("@opdcs1", consultation.OPDConsent1.Trim)
            cmd.Parameters.AddWithValue("@opdcs2", consultation.OPDConsent2.Trim)
            cmd.Parameters.AddWithValue("@forinit_svrasnctr_ID", consultation.ForInitialConsultation_ServerAssignCounter_ID)
            cmd.Parameters.AddWithValue("@FK_psPat", consultation.FK_psPatRegisters)
            cmd.Parameters.AddWithValue("@FK_emd", consultation.FK_emdPatients)
            cmd.Parameters.AddWithValue("@inf_id", consultation.Info_ID)
            cmd.Parameters.AddWithValue("@svrtrns_id", consultation.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@svdcust_id", consultation.ServedCustomerID)
            Return WMMCQMSConfig.excecuteCommand(cmd)
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientBizboxConsultation(ByVal conID As Long) As Bizbox_Consultation
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT  
                                    a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                    b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                    c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                    e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                    g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                    h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                    i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                    j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                    k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                    l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                    FROM [dbo].[bizbox_consultation] as a
                                    JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                    JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                    JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                    JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                    JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                    JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                    JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                    JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                    JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                    JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                    JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE a.[consultation_id] = @ID"
            }
            cmd.Parameters.AddWithValue("@ID", conID)
            Dim expression As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (Not Information.IsNothing(expression) AndAlso (expression.Rows.Count > 0)) Then
                Dim consultation As New Bizbox_Consultation
                consultation.ID = (expression.Rows(0)("a_consultation_id"))
                consultation.DateCreated = (expression.Rows(0)("a_datecreated"))
                consultation.DateModified = If(Not Information.IsDBNull((expression.Rows(0)("a_datemodified"))), expression.Rows(0)("a_datemodified"), Nothing)
                consultation.OPDConsent1 = (expression.Rows(0)("a_opdconsent1"))
                consultation.OPDConsent2 = (expression.Rows(0)("a_opdconsent2"))
                consultation.isServed = (expression.Rows(0)("a_isServed"))
                consultation.ForInitialConsultation_ServerAssignCounter_ID = (expression.Rows(0)("a_forinitialconsult_serverassigncounter_ID"))
                consultation.FK_psPatRegisters = (expression.Rows(0)("a_FK_psPatRegisters"))
                consultation.FK_emdPatients = (expression.Rows(0)("a_FK_emdPatients"))
                consultation.Info_ID = (expression.Rows(0)("a_info_id"))
                consultation.ServerTransaction_ID = (expression.Rows(0)("a_servertransaction_id"))
                consultation.ServedCustomerID = (expression.Rows(0)("a_servedcustomer_id"))
                consultation.ServerTransaction = New ServerTransaction
                consultation.ServerTransaction.ServerTransaction_ID = (expression.Rows(0)("e_servertransaction_id"))
                consultation.ServerTransaction.ServerAssignCounter_ID = (expression.Rows(0)("e_serverassigncounter_id"))
                consultation.ServerTransaction.CounterName = (expression.Rows(0)("e_countername"))
                consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (expression.Rows(0)("f_serverassigncounter_ID"))
                consultation.ServerTransaction.ServerAssignCounter.Server_ID = (expression.Rows(0)("f_server_id"))
                consultation.ServerTransaction.ServerAssignCounter.Counter_ID = (expression.Rows(0)("f_counter_id"))
                consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (expression.Rows(0)("h_counter_id"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.Department = (expression.Rows(0)("h_department"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.Section = (expression.Rows(0)("h_section"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (expression.Rows(0)("h_servicedescription"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (expression.Rows(0)("h_counterPrefix"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = (expression.Rows(0)("h_icon"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = (expression.Rows(0)("h_consultationView"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (expression.Rows(0)("h_consultationAddEdit"))
                consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = (expression.Rows(0)("g_server_id"))
                consultation.ServerTransaction.ServerAssignCounter.Server.FullName = (expression.Rows(0)("g_fullname"))
                consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (expression.Rows(0)("g_assigndepartment"))
                consultation.ServerTransaction.ServerAssignCounter.Server.PRC = (expression.Rows(0)("g_prc"))
                consultation.ServerTransaction.ServerAssignCounter.Server.PTR = (expression.Rows(0)("g_ptr"))
                consultation.ServerTransaction.ServerAssignCounter.Server.S2No = (expression.Rows(0)("g_s2"))
                consultation.ServedCustomer = New ServedCustomer
                consultation.ServedCustomer.ServedCustomer_ID = (expression.Rows(0)("b_served_id"))
                consultation.ServedCustomer.ServerTransaction_ID = (expression.Rows(0)("b_servertransaction_id"))
                consultation.ServedCustomer.CustomerAssginCounter_ID = (expression.Rows(0)("b_customerassigncounter_id"))
                consultation.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull((expression.Rows(0)("b_datetimeservedstart"))), expression.Rows(0)("b_datetimeservedstart"), Nothing)
                consultation.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull((expression.Rows(0)("b_datetimeservedend"))), expression.Rows(0)("b_datetimeservedend"), Nothing)
                consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (expression.Rows(0)("c_customerassigncounter_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = (expression.Rows(0)("c_counter_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = (expression.Rows(0)("c_customer_id"))
                consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (expression.Rows(0)("c_datetimequeued"))
                consultation.ServedCustomer.CustomerAssignCounter.Priority = (expression.Rows(0)("c_priority"))
                consultation.ServedCustomer.CustomerAssignCounter.Result = (expression.Rows(0)("c_result"))
                consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = (expression.Rows(0)("c_queuenumber"))
                consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = (expression.Rows(0)("c_paymentmethod"))
                consultation.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull((expression.Rows(0)("c_notes"))), expression.Rows(0)("c_notes"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull((expression.Rows(0)("c_notedepartment"))), expression.Rows(0)("c_notedepartment"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull((expression.Rows(0)("c_notesection"))), expression.Rows(0)("c_notesection"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (expression.Rows(0)("d_customer_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull((expression.Rows(0)("d_fullname"))), expression.Rows(0)("d_fullname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull((expression.Rows(0)("d_firstname"))), expression.Rows(0)("d_firstname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull((expression.Rows(0)("d_middlename"))), expression.Rows(0)("d_middlename"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull((expression.Rows(0)("d_lastname"))), expression.Rows(0)("d_lastname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull((expression.Rows(0)("d_sex"))), expression.Rows(0)("d_sex"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull((expression.Rows(0)("d_birthdate"))), expression.Rows(0)("d_birthdate"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull((expression.Rows(0)("d_civilstatus"))), expression.Rows(0)("d_civilstatus"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull((expression.Rows(0)("d_address"))), expression.Rows(0)("d_address"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull((expression.Rows(0)("d_phonenumber"))), expression.Rows(0)("d_phonenumber"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (expression.Rows(0)("d_dateofvisit"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull((expression.Rows(0)("d_FK_emdPatients"))), expression.Rows(0)("d_FK_emdPatients"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull((expression.Rows(0)("d_info_id"))), expression.Rows(0)("d_info_id"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (expression.Rows(0)("i_info_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull((expression.Rows(0)("i_firstname"))), expression.Rows(0)("i_firstname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull((expression.Rows(0)("i_middlename"))), expression.Rows(0)("i_middlename"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull((expression.Rows(0)("i_middlename"))), expression.Rows(0)("i_middlename"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull((expression.Rows(0)("i_sex"))), expression.Rows(0)("i_sex"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull((expression.Rows(0)("i_birthdate"))), expression.Rows(0)("i_birthdate"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull((expression.Rows(0)("i_civilstatus"))), expression.Rows(0)("i_civilstatus"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull((expression.Rows(0)("i_street"))), expression.Rows(0)("i_street"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull((expression.Rows(0)("i_barangay"))), expression.Rows(0)("i_barangay"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull((expression.Rows(0)("i_city"))), expression.Rows(0)("i_city"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull((expression.Rows(0)("i_phonenumber"))), expression.Rows(0)("i_phonenumber"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull((expression.Rows(0)("i_nationality"))), expression.Rows(0)("i_nationality"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull((expression.Rows(0)("i_picturelocation"))), expression.Rows(0)("i_picturelocation"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull((expression.Rows(0)("i_FK_emdPatients"))), expression.Rows(0)("i_FK_emdPatients"), Nothing))
                consultation.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                consultation.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (expression.Rows(0)("j_serverassigncounter_ID"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server_ID = (expression.Rows(0)("j_server_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter_ID = (expression.Rows(0)("j_counter_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (expression.Rows(0)("l_counter_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Department = (expression.Rows(0)("l_department"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Section = (expression.Rows(0)("l_section"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (expression.Rows(0)("l_servicedescription"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (expression.Rows(0)("l_counterPrefix"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (expression.Rows(0)("l_icon"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (expression.Rows(0)("l_consultationView"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (expression.Rows(0)("l_consultationAddEdit"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server = New Server
                consultation.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (expression.Rows(0)("k_server_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.FullName = (expression.Rows(0)("k_fullname"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (expression.Rows(0)("k_assigndepartment"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC = (expression.Rows(0)("k_prc"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.PTR = (expression.Rows(0)("k_ptr"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.S2No = (expression.Rows(0)("k_s2"))
                consultation.BizboxRegistration = New BizboxAPI().GetCertainPatientRegistration(consultation.FK_psPatRegisters)
                Return consultation
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientBizboxConsultation2(ByVal conID As Long, ByVal rodID As Long) As Bizbox_Consultation
         Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT  
                                    a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                    b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                    c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                    e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                    g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                    h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                    i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                    j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                    k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                    l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                    FROM [dbo].[bizbox_consultation] as a
                                    JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                    JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                    JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                    JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                    JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                    JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                    JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                    JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                    JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                    JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                    JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE a.[consultation_id] = @ID"
            }
            cmd.Parameters.AddWithValue("@ID", conID)
            Dim expression As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (Not Information.IsNothing(expression) AndAlso (expression.Rows.Count > 0)) Then
                Dim consultation As New Bizbox_Consultation
                consultation.ID = (expression.Rows(0)("a_consultation_id"))
                consultation.DateCreated = (expression.Rows(0)("a_datecreated"))
                consultation.DateModified = If(Not Information.IsDBNull((expression.Rows(0)("a_datemodified"))), expression.Rows(0)("a_datemodified"), Nothing)
                consultation.OPDConsent1 = (expression.Rows(0)("a_opdconsent1"))
                consultation.OPDConsent2 = (expression.Rows(0)("a_opdconsent2"))
                consultation.isServed = (expression.Rows(0)("a_isServed"))
                consultation.ForInitialConsultation_ServerAssignCounter_ID = (expression.Rows(0)("a_forinitialconsult_serverassigncounter_ID"))
                consultation.FK_psPatRegisters = (expression.Rows(0)("a_FK_psPatRegisters"))
                consultation.FK_emdPatients = (expression.Rows(0)("a_FK_emdPatients"))
                consultation.Info_ID = (expression.Rows(0)("a_info_id"))
                consultation.ServerTransaction_ID = (expression.Rows(0)("a_servertransaction_id"))
                consultation.ServedCustomerID = (expression.Rows(0)("a_servedcustomer_id"))
                consultation.ServerTransaction = New ServerTransaction
                consultation.ServerTransaction.ServerTransaction_ID = (expression.Rows(0)("e_servertransaction_id"))
                consultation.ServerTransaction.ServerAssignCounter_ID = (expression.Rows(0)("e_serverassigncounter_id"))
                consultation.ServerTransaction.CounterName = (expression.Rows(0)("e_countername"))
                consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (expression.Rows(0)("f_serverassigncounter_ID"))
                consultation.ServerTransaction.ServerAssignCounter.Server_ID = (expression.Rows(0)("f_server_id"))
                consultation.ServerTransaction.ServerAssignCounter.Counter_ID = (expression.Rows(0)("f_counter_id"))
                consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (expression.Rows(0)("h_counter_id"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.Department = (expression.Rows(0)("h_department"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.Section = (expression.Rows(0)("h_section"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (expression.Rows(0)("h_servicedescription"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (expression.Rows(0)("h_counterPrefix"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = (expression.Rows(0)("h_icon"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = (expression.Rows(0)("h_consultationView"))
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (expression.Rows(0)("h_consultationAddEdit"))
                consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = (expression.Rows(0)("g_server_id"))
                consultation.ServerTransaction.ServerAssignCounter.Server.FullName = (expression.Rows(0)("g_fullname"))
                consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (expression.Rows(0)("g_assigndepartment"))
                consultation.ServerTransaction.ServerAssignCounter.Server.PRC = (expression.Rows(0)("g_prc"))
                consultation.ServerTransaction.ServerAssignCounter.Server.PTR = (expression.Rows(0)("g_ptr"))
                consultation.ServerTransaction.ServerAssignCounter.Server.S2No = (expression.Rows(0)("g_s2"))
                consultation.ServedCustomer = New ServedCustomer
                consultation.ServedCustomer.ServedCustomer_ID = (expression.Rows(0)("b_served_id"))
                consultation.ServedCustomer.ServerTransaction_ID = (expression.Rows(0)("b_servertransaction_id"))
                consultation.ServedCustomer.CustomerAssginCounter_ID = (expression.Rows(0)("b_customerassigncounter_id"))
                consultation.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull((expression.Rows(0)("b_datetimeservedstart"))), expression.Rows(0)("b_datetimeservedstart"), Nothing)
                consultation.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull((expression.Rows(0)("b_datetimeservedend"))), expression.Rows(0)("b_datetimeservedend"), Nothing)
                consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (expression.Rows(0)("c_customerassigncounter_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = (expression.Rows(0)("c_counter_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = (expression.Rows(0)("c_customer_id"))
                consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (expression.Rows(0)("c_datetimequeued"))
                consultation.ServedCustomer.CustomerAssignCounter.Priority = (expression.Rows(0)("c_priority"))
                consultation.ServedCustomer.CustomerAssignCounter.Result = (expression.Rows(0)("c_result"))
                consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = (expression.Rows(0)("c_queuenumber"))
                consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = (expression.Rows(0)("c_paymentmethod"))
                consultation.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull((expression.Rows(0)("c_notes"))), expression.Rows(0)("c_notes"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull((expression.Rows(0)("c_notedepartment"))), expression.Rows(0)("c_notedepartment"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull((expression.Rows(0)("c_notesection"))), expression.Rows(0)("c_notesection"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (expression.Rows(0)("d_customer_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull((expression.Rows(0)("d_fullname"))), expression.Rows(0)("d_fullname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull((expression.Rows(0)("d_firstname"))), expression.Rows(0)("d_firstname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull((expression.Rows(0)("d_middlename"))), expression.Rows(0)("d_middlename"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull((expression.Rows(0)("d_lastname"))), expression.Rows(0)("d_lastname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull((expression.Rows(0)("d_sex"))), expression.Rows(0)("d_sex"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull((expression.Rows(0)("d_birthdate"))), expression.Rows(0)("d_birthdate"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull((expression.Rows(0)("d_civilstatus"))), expression.Rows(0)("d_civilstatus"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull((expression.Rows(0)("d_address"))), expression.Rows(0)("d_address"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull((expression.Rows(0)("d_phonenumber"))), expression.Rows(0)("d_phonenumber"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (expression.Rows(0)("d_dateofvisit"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull((expression.Rows(0)("d_FK_emdPatients"))), expression.Rows(0)("d_FK_emdPatients"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull((expression.Rows(0)("d_info_id"))), expression.Rows(0)("d_info_id"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (expression.Rows(0)("i_info_id"))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull((expression.Rows(0)("i_firstname"))), expression.Rows(0)("i_firstname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull((expression.Rows(0)("i_middlename"))), expression.Rows(0)("i_middlename"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull((expression.Rows(0)("i_lastname"))), expression.Rows(0)("i_lastname"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull((expression.Rows(0)("i_sex"))), expression.Rows(0)("i_sex"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull((expression.Rows(0)("i_birthdate"))), expression.Rows(0)("i_birthdate"), Nothing))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull((expression.Rows(0)("i_civilstatus"))), expression.Rows(0)("i_civilstatus"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull((expression.Rows(0)("i_street"))), expression.Rows(0)("i_street"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull((expression.Rows(0)("i_barangay"))), expression.Rows(0)("i_barangay"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull((expression.Rows(0)("i_city"))), expression.Rows(0)("i_city"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull((expression.Rows(0)("i_phonenumber"))), expression.Rows(0)("i_phonenumber"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull((expression.Rows(0)("i_nationality"))), expression.Rows(0)("i_nationality"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull((expression.Rows(0)("i_picturelocation"))), expression.Rows(0)("i_picturelocation"), ""))
                consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull((expression.Rows(0)("i_FK_emdPatients"))), expression.Rows(0)("i_FK_emdPatients"), Nothing))
                consultation.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                consultation.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (expression.Rows(0)("j_serverassigncounter_ID"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server_ID = (expression.Rows(0)("j_server_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter_ID = (expression.Rows(0)("j_counter_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (expression.Rows(0)("l_counter_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Department = (expression.Rows(0)("l_department"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Section = (expression.Rows(0)("l_section"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (expression.Rows(0)("l_servicedescription"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (expression.Rows(0)("l_counterPrefix"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (expression.Rows(0)("l_icon"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (expression.Rows(0)("l_consultationView"))
                consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (expression.Rows(0)("l_consultationAddEdit"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server = New Server
                consultation.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (expression.Rows(0)("k_server_id"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.FullName = (expression.Rows(0)("k_fullname"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (expression.Rows(0)("k_assigndepartment"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC = (expression.Rows(0)("k_prc"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.PTR = (expression.Rows(0)("k_ptr"))
                consultation.ForInitialConsultation_ServerAssignCounter.Server.S2No = (expression.Rows(0)("k_s2"))
                consultation.BizboxRegistration = New BizboxAPI().GetCertainPatientRegistration2(consultation.FK_psPatRegisters, rodID)
                Return consultation
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetBizboxLatestCustomerConsultation(ByVal infoID As Long, ByVal fkEmdPatient As Long) As Bizbox_Consultation
        Try
            Dim cmd As New SqlCommand
            Dim str As String = ""
            If (fkEmdPatient > 0) Then
                str = "or f.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = ("SELECT a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                        b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                        c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                        e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                        g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                        h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                        i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                        j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                        k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                        l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                        FROM [dbo].[bizbox_consultation] as a
                                        JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                        JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                        JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                        JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                        JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                        JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                        JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                        JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                        JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                        JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                        JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE [isServed] = 0 AND CONVERT(DATE, a.datecreated) = CONVERT(DATE, GETDATE()) AND [consultation_id] = (SELECT MAX([consultation_id]) from [bizbox_consultation] as f WHERE f.info_id = @ID " & str & ")")
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If Not Information.IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim consultation As New Bizbox_Consultation
                    consultation.ID = (data.Rows(0)("a_consultation_id"))
                    consultation.DateCreated = (data.Rows(0)("a_datecreated"))
                    consultation.DateModified = If(Not Information.IsDBNull((data.Rows(0)("a_datemodified"))), data.Rows(0)("a_datemodified"), Nothing)
                    consultation.OPDConsent1 = (data.Rows(0)("a_opdconsent1"))
                    consultation.OPDConsent2 = (data.Rows(0)("a_opdconsent2"))
                    consultation.isServed = (data.Rows(0)("a_isServed"))
                    consultation.ForInitialConsultation_ServerAssignCounter_ID = (data.Rows(0)("a_forinitialconsult_serverassigncounter_ID"))
                    consultation.FK_psPatRegisters = (data.Rows(0)("a_FK_psPatRegisters"))
                    consultation.FK_emdPatients = (data.Rows(0)("a_FK_emdPatients"))
                    consultation.Info_ID = (data.Rows(0)("a_info_id"))
                    consultation.ServerTransaction_ID = (data.Rows(0)("a_servertransaction_id"))
                    consultation.ServedCustomerID = (data.Rows(0)("a_servedcustomer_id"))
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = (data.Rows(0)("e_servertransaction_id"))
                    consultation.ServerTransaction.ServerAssignCounter_ID = (data.Rows(0)("e_serverassigncounter_id"))
                    consultation.ServerTransaction.CounterName = (data.Rows(0)("e_countername"))
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("f_serverassigncounter_ID"))
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = (data.Rows(0)("f_server_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = (data.Rows(0)("f_counter_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("h_counter_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = (data.Rows(0)("h_department"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = (data.Rows(0)("h_section"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("h_servicedescription"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("h_counterPrefix"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = (data.Rows(0)("h_icon"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = (data.Rows(0)("h_consultationView"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("h_consultationAddEdit"))
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = (data.Rows(0)("g_server_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = (data.Rows(0)("g_fullname"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("g_assigndepartment"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = (data.Rows(0)("g_prc"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = (data.Rows(0)("g_ptr"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.S2No = (data.Rows(0)("g_s2"))
                    consultation.ServedCustomer = New ServedCustomer
                    consultation.ServedCustomer.ServedCustomer_ID = (data.Rows(0)("b_served_id"))
                    consultation.ServedCustomer.ServerTransaction_ID = (data.Rows(0)("b_servertransaction_id"))
                    consultation.ServedCustomer.CustomerAssginCounter_ID = (data.Rows(0)("b_customerassigncounter_id"))
                    consultation.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull((data.Rows(0)("b_datetimeservedstart"))), data.Rows(0)("b_datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull((data.Rows(0)("b_datetimeservedend"))), data.Rows(0)("b_datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (data.Rows(0)("c_customerassigncounter_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = (data.Rows(0)("c_counter_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = (data.Rows(0)("c_customer_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (data.Rows(0)("c_datetimequeued"))
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = (data.Rows(0)("c_priority"))
                    consultation.ServedCustomer.CustomerAssignCounter.Result = (data.Rows(0)("c_result"))
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = (data.Rows(0)("c_queuenumber"))
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = (data.Rows(0)("c_paymentmethod"))
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull((data.Rows(0)("c_notes"))), data.Rows(0)("c_notes"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull((data.Rows(0)("c_notedepartment"))), data.Rows(0)("c_notedepartment"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull((data.Rows(0)("c_notesection"))), data.Rows(0)("c_notesection"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (data.Rows(0)("d_customer_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull((data.Rows(0)("d_fullname"))), data.Rows(0)("d_fullname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("d_firstname"))), data.Rows(0)("d_firstname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull((data.Rows(0)("d_middlename"))), data.Rows(0)("d_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull((data.Rows(0)("d_lastname"))), data.Rows(0)("d_lastname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull((data.Rows(0)("d_sex"))), data.Rows(0)("d_sex"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull((data.Rows(0)("d_birthdate"))), data.Rows(0)("d_birthdate"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("d_civilstatus"))), data.Rows(0)("d_civilstatus"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull((data.Rows(0)("d_address"))), data.Rows(0)("d_address"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("d_phonenumber"))), data.Rows(0)("d_phonenumber"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (data.Rows(0)("d_dateofvisit"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("d_FK_emdPatients"))), data.Rows(0)("d_FK_emdPatients"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull((data.Rows(0)("d_info_id"))), data.Rows(0)("d_info_id"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (data.Rows(0)("i_info_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("i_firstname"))), data.Rows(0)("i_firstname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull((data.Rows(0)("i_sex"))), data.Rows(0)("i_sex"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull((data.Rows(0)("i_birthdate"))), data.Rows(0)("i_birthdate"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("i_civilstatus"))), data.Rows(0)("i_civilstatus"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull((data.Rows(0)("i_street"))), data.Rows(0)("i_street"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull((data.Rows(0)("i_barangay"))), data.Rows(0)("i_barangay"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull((data.Rows(0)("i_city"))), data.Rows(0)("i_city"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("i_phonenumber"))), data.Rows(0)("i_phonenumber"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull((data.Rows(0)("i_nationality"))), data.Rows(0)("i_nationality"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull((data.Rows(0)("i_picturelocation"))), data.Rows(0)("i_picturelocation"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("i_FK_emdPatients"))), data.Rows(0)("i_FK_emdPatients"), Nothing))
                    consultation.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                    consultation.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("j_serverassigncounter_ID"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server_ID = (data.Rows(0)("j_server_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter_ID = (data.Rows(0)("j_counter_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("l_counter_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Department = (data.Rows(0)("l_department"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Section = (data.Rows(0)("l_section"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("l_servicedescription"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("l_counterPrefix"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (data.Rows(0)("l_icon"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (data.Rows(0)("l_consultationView"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("l_consultationAddEdit"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server = New Server
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (data.Rows(0)("k_server_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.FullName = (data.Rows(0)("k_fullname"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("k_assigndepartment"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC = (data.Rows(0)("k_prc"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.PTR = (data.Rows(0)("k_ptr"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.S2No = (data.Rows(0)("k_s2"))
                    consultation.BizboxRegistration = New BizboxAPI().GetCertainPatientRegistration(consultation.FK_psPatRegisters)
                    Return consultation
                End If
            End If
            Return Nothing
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function


    Public Function GetIfExistConsultation(ByVal psPatRegister As Long) As Bizbox_Consultation
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT
                                a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',
                                d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',
                                f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                FROM [dbo].[bizbox_consultation] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE FK_psPatRegisters = @ID"
            }
            cmd.Parameters.AddWithValue("@ID", psPatRegister)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim consultation As New Bizbox_Consultation
                    consultation.ID = (data.Rows(0)("a_consultation_id"))
                    consultation.DateCreated = (data.Rows(0)("a_datecreated"))
                    consultation.DateModified = If(Not Information.IsDBNull(data.Rows(0)("a_datemodified")), data.Rows(0)("a_datemodified"), Nothing)
                    consultation.OPDConsent1 = (data.Rows(0)("a_opdconsent1"))
                    consultation.OPDConsent2 = (data.Rows(0)("a_opdconsent2"))
                    consultation.isServed = (data.Rows(0)("a_isServed"))
                    consultation.ForInitialConsultation_ServerAssignCounter_ID = (data.Rows(0)("a_forinitialconsult_serverassigncounter_ID"))
                    consultation.FK_psPatRegisters = (data.Rows(0)("a_FK_psPatRegisters"))
                    consultation.FK_emdPatients = (data.Rows(0)("a_FK_emdPatients"))
                    consultation.Info_ID = (data.Rows(0)("a_info_id"))
                    consultation.ServerTransaction_ID = (data.Rows(0)("a_servertransaction_id"))
                    consultation.ServedCustomerID = (data.Rows(0)("a_servedcustomer_id"))
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = (data.Rows(0)("e_servertransaction_id"))
                    consultation.ServerTransaction.ServerAssignCounter_ID = (data.Rows(0)("e_serverassigncounter_id"))
                    consultation.ServerTransaction.CounterName = (data.Rows(0)("e_countername"))
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("f_serverassigncounter_ID"))
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = (data.Rows(0)("f_server_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = (data.Rows(0)("f_counter_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("h_counter_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = (data.Rows(0)("h_department"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = (data.Rows(0)("h_section"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("h_servicedescription"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("h_counterPrefix"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = (data.Rows(0)("h_icon"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = (data.Rows(0)("h_consultationView"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("h_consultationAddEdit"))
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = (data.Rows(0)("g_server_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = (data.Rows(0)("g_fullname"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("g_assigndepartment"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = (data.Rows(0)("g_prc"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = (data.Rows(0)("g_ptr"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.S2No = (data.Rows(0)("g_s2"))
                    consultation.ServedCustomer = New ServedCustomer
                    consultation.ServedCustomer.ServedCustomer_ID = (data.Rows(0)("b_served_id"))
                    consultation.ServedCustomer.ServerTransaction_ID = (data.Rows(0)("b_servertransaction_id"))
                    consultation.ServedCustomer.CustomerAssginCounter_ID = (data.Rows(0)("b_customerassigncounter_id"))
                    consultation.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull((data.Rows(0)("b_datetimeservedstart"))), data.Rows(0)("b_datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull((data.Rows(0)("b_datetimeservedend"))), data.Rows(0)("b_datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (data.Rows(0)("c_customerassigncounter_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = (data.Rows(0)("c_counter_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = (data.Rows(0)("c_customer_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (data.Rows(0)("c_datetimequeued"))
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = (data.Rows(0)("c_priority"))
                    consultation.ServedCustomer.CustomerAssignCounter.Result = (data.Rows(0)("c_result"))
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = (data.Rows(0)("c_queuenumber"))
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = (data.Rows(0)("c_paymentmethod"))
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull((data.Rows(0)("c_notes"))), data.Rows(0)("c_notes"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull((data.Rows(0)("c_notedepartment"))), data.Rows(0)("c_notedepartment"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull((data.Rows(0)("c_notesection"))), data.Rows(0)("c_notesection"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (data.Rows(0)("d_customer_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull((data.Rows(0)("d_fullname"))), data.Rows(0)("d_fullname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("d_firstname"))), data.Rows(0)("d_firstname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull((data.Rows(0)("d_middlename"))), data.Rows(0)("d_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull((data.Rows(0)("d_lastname"))), data.Rows(0)("d_lastname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull((data.Rows(0)("d_sex"))), data.Rows(0)("d_sex"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull((data.Rows(0)("d_birthdate"))), data.Rows(0)("d_birthdate"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("d_civilstatus"))), data.Rows(0)("d_civilstatus"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull((data.Rows(0)("d_address"))), data.Rows(0)("d_address"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("d_phonenumber"))), data.Rows(0)("d_phonenumber"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (data.Rows(0)("d_dateofvisit"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("d_FK_emdPatients"))), data.Rows(0)("d_FK_emdPatients"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull((data.Rows(0)("d_info_id"))), data.Rows(0)("d_info_id"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (data.Rows(0)("i_info_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("i_firstname"))), data.Rows(0)("i_firstname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull((data.Rows(0)("i_sex"))), data.Rows(0)("i_sex"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull((data.Rows(0)("i_birthdate"))), data.Rows(0)("i_birthdate"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("i_civilstatus"))), data.Rows(0)("i_civilstatus"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull((data.Rows(0)("i_street"))), data.Rows(0)("i_street"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull((data.Rows(0)("i_barangay"))), data.Rows(0)("i_barangay"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull((data.Rows(0)("i_city"))), data.Rows(0)("i_city"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("i_phonenumber"))), data.Rows(0)("i_phonenumber"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull((data.Rows(0)("i_nationality"))), data.Rows(0)("i_nationality"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull((data.Rows(0)("i_picturelocation"))), data.Rows(0)("i_picturelocation"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("i_FK_emdPatients"))), data.Rows(0)("i_FK_emdPatients"), Nothing))
                    consultation.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                    consultation.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("j_serverassigncounter_ID"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server_ID = (data.Rows(0)("j_server_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter_ID = (data.Rows(0)("j_counter_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("l_counter_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Department = (data.Rows(0)("l_department"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Section = (data.Rows(0)("l_section"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("l_servicedescription"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("l_counterPrefix"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (data.Rows(0)("l_icon"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (data.Rows(0)("l_consultationView"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("l_consultationAddEdit"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server = New Server
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (data.Rows(0)("k_server_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.FullName = (data.Rows(0)("k_fullname"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("k_assigndepartment"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC = (data.Rows(0)("k_prc"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.PTR = (data.Rows(0)("k_ptr"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.S2No = (data.Rows(0)("k_s2"))
                    Return consultation
                End If
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetIfExistConsultation2(ByVal psPatRegister As Long, ByVal prc As String) As Bizbox_Consultation
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT
                                a.consultation_id as 'a_consultation_id',a.datecreated as 'a_datecreated',a.datemodified as 'a_datemodified',a.opdconsent1 as 'a_opdconsent1',a.opdconsent2 as 'a_opdconsent2',a.isServed as 'a_isServed',a.forinitialconsult_serverassigncounter_ID as 'a_forinitialconsult_serverassigncounter_ID',a.FK_psPatRegisters as 'a_FK_psPatRegisters',a.FK_emdPatients as 'a_FK_emdPatients',a.info_id as 'a_info_id',a.servertransaction_id as 'a_servertransaction_id',a.servedcustomer_id as 'a_servedcustomer_id',
                                b.served_id as 'b_served_id',b.servertransaction_id as 'b_servertransaction_id',b.customerassigncounter_id as 'b_customerassigncounter_id',b.datetimeservedstart as 'b_datetimeservedstart',b.datetimeservedend as 'b_datetimeservedend',
                                c.customerassigncounter_id as 'c_customerassigncounter_id',c.counter_id as 'c_counter_id',c.customer_id as 'c_customer_id',c.datetimequeued as 'c_datetimequeued',c.customerassigncounter_id as 'c_priority',c.forHelee as 'c_forHelee',c.result as 'c_result',c.queuenumber as 'c_queuenumber',c.paymentmethod as 'c_paymentmethod',c.notes as 'c_notes',c.notedepartment as 'c_notedepartment',c.notesection as 'c_notesection',c.showFlag as 'c_showFlag',
                                d.customer_id as 'd_customer_id',d.fullname as 'd_fullname',d.firstname as 'd_firstname',d.middlename as 'd_middlename',d.lastname as 'd_lastname',d.sex as 'd_sex',d.birthdate as 'd_birthdate',d.civilstatus as 'd_civilstatus',d.address as 'd_address',d.phonenumber as 'd_phonenumber',d.dateofvisit as 'd_dateofvisit',d.FK_emdPatients as 'd_FK_emdPatients',d.info_id as 'd_info_id',
                                e.servertransaction_id as 'e_servertransaction_id',e.serverassigncounter_id as 'e_serverassigncounter_id',e.countername as 'e_countername',e.datetimelogin as 'e_datetimelogin',e.datetimelogout as 'e_datetimelogout',
                                f.serverassigncounter_ID as 'f_serverassigncounter_ID',f.server_id as 'f_server_id',f.counter_id as 'f_counter_id',f.datecreated as 'f_datecreated',f.isMain as 'f_isMain',
                                g.server_id as 'g_server_id',g.employee_id as 'g_employee_id',g.fullname as 'g_fullname',g.assigndepartment as 'g_assigndepartment',g.firstname as 'g_firstname',g.middlename as 'g_middlename',g.lastname as 'g_lastname',g.specializaton as 'g_specializaton',g.ptr as 'g_ptr',g.prc as 'g_prc',g.accountType as 'g_accountType',g.physician_id as 'g_physician_id',g.s2 as 'g_s2',g.digitalSignature as 'g_digitalSignature',
                                h.counter_id as 'h_counter_id',h.department as 'h_department',h.section as 'h_section',h.servicedescription as 'h_servicedescription',h.servicedescription2 as 'h_servicedescription2',h.counterPrefix as 'h_counterPrefix',h.countercode as 'h_countercode',h.icon as 'h_icon',h.isQueuingCounter as 'h_isQueuingCounter',h.autotransfer_diagnosticrequest as 'h_autotransfer_diagnosticrequest',h.autotransfer_prescriptiobrequest as 'h_autotransfer_prescriptiobrequest',h.autotransfer_screening as 'h_autotransfer_screening',h.autotransfer_payment as 'h_autotransfer_payment',h.autotransfer_gcber as 'h_autotransfer_gcber',h.autotransfer_respiber as 'h_autotransfer_respiber',h.counterType as 'h_counterType',h.isResultCounter as 'h_isResultCounter',h.canCustomerName as 'h_canCustomerName',h.canPaymentMethod as 'h_canPaymentMethod',h.allowableTurnaroundTime as 'h_allowableTurnaroundTime',h.consultationView as 'h_consultationView',h.consultationAddEdit as 'h_consultationAddEdit',h.diagnosticView as 'h_diagnosticView',h.diagnosticAddEdit as 'h_diagnosticAddEdit',h.eprescirptionView as 'h_eprescirptionView',h.eprescirptionAddEdit as 'h_eprescirptionAddEdit',h.healthcheckView as 'h_healthcheckView',h.healthcheckAddEdit as 'h_healthcheckAddEdit',h.initialconsultation as 'h_initialconsultation',h.erconsultation as 'h_erconsultation',h.syncDetail as 'h_syncDetail',h.fk_counter_id as 'h_fk_counter_id',h.counterStepByStep as 'h_counterStepByStep',h.generateScreening as 'h_generateScreening',h.canEKonsulta as 'h_canEKonsulta',h.canHelee as 'h_canHelee',
                                i.info_id as 'i_info_id',i.firstname as 'i_firstname',i.middlename as 'i_middlename',i.lastname as 'i_lastname',i.sex as 'i_sex',i.birthdate as 'i_birthdate',i.civilstatus as 'i_civilstatus',i.street as 'i_street',i.barangay as 'i_barangay',i.city as 'i_city',i.phonenumber as 'i_phonenumber',i.nationality as 'i_nationality',i.email as 'i_email',i.picturelocation as 'i_picturelocation',i.FK_emdPatients as 'i_FK_emdPatients',
                                j.serverassigncounter_ID as 'j_serverassigncounter_ID',j.server_id as 'j_server_id',j.counter_id as 'j_counter_id',j.datecreated as 'j_datecreated',j.isMain as 'j_isMain',
                                k.server_id as 'k_server_id',k.employee_id as 'k_employee_id',k.fullname as 'k_fullname',k.assigndepartment as 'k_assigndepartment',k.firstname as 'k_firstname',k.middlename as 'k_middlename',k.lastname as 'k_lastname',k.specializaton as 'k_specializaton',k.ptr as 'k_ptr',k.prc as 'k_prc',k.accountType as 'k_accountType',k.physician_id as 'k_physician_id',k.s2 as 'k_s2',k.digitalSignature as 'k_digitalSignature',
                                l.counter_id as 'l_counter_id',l.department as 'l_department',l.section as 'l_section',l.servicedescription as 'l_servicedescription',l.servicedescription2 as 'l_servicedescription2',l.counterPrefix as 'l_counterPrefix',l.countercode as 'l_countercode',l.icon as 'l_icon',l.isQueuingCounter as 'l_isQueuingCounter',l.autotransfer_diagnosticrequest as 'l_autotransfer_diagnosticrequest',l.autotransfer_prescriptiobrequest as 'l_autotransfer_prescriptiobrequest',l.autotransfer_screening as 'l_autotransfer_screening',l.autotransfer_payment as 'l_autotransfer_payment',l.autotransfer_gcber as 'l_autotransfer_gcber',l.autotransfer_respiber as 'l_autotransfer_respiber',l.counterType as 'l_counterType',l.isResultCounter as 'l_isResultCounter',l.canCustomerName as 'l_canCustomerName',l.canPaymentMethod as 'l_canPaymentMethod',l.allowableTurnaroundTime as 'l_allowableTurnaroundTime',l.consultationView as 'l_consultationView',l.consultationAddEdit as 'l_consultationAddEdit',l.diagnosticView as 'l_diagnosticView',l.diagnosticAddEdit as 'l_diagnosticAddEdit',l.eprescirptionView as 'l_eprescirptionView',l.eprescirptionAddEdit as 'l_eprescirptionAddEdit',l.healthcheckView as 'l_healthcheckView',l.healthcheckAddEdit as 'l_healthcheckAddEdit',l.initialconsultation as 'l_initialconsultation',l.erconsultation as 'l_erconsultation',l.syncDetail as 'l_syncDetail',l.fk_counter_id as 'l_fk_counter_id',l.counterStepByStep as 'l_counterStepByStep',l.generateScreening as 'l_generateScreening',l.canEKonsulta as 'l_canEKonsulta',l.canHelee as 'l_canHelee'
                                FROM [dbo].[bizbox_consultation] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.servedcustomer_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on  c.customerassigncounter_id = b.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on d.customer_id = c.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on e.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on f.serverassigncounter_ID = e.serverassigncounter_id
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on i.info_id = d.info_id
                                JOIN [wmmcqms].[serverassigncounter] as j on j.serverassigncounter_id = a.forinitialconsult_serverassigncounter_ID
                                JOIN [wmmcqms].[server] as k on k.server_id = j.server_id
                                JOIN [wmmcqms].[counter] as l on l.counter_id = j.counter_id
                                WHERE FK_psPatRegisters = @patreg AND (g.prc = @prcno or k.prc = @prcno)"
            }
            cmd.Parameters.AddWithValue("@patreg", psPatRegister)
            cmd.Parameters.AddWithValue("@prcno", prc.Trim)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim consultation As New Bizbox_Consultation
                    consultation.ID = (data.Rows(0)("a_consultation_id"))
                    consultation.DateCreated = (data.Rows(0)("a_datecreated"))
                    consultation.DateModified = If(Not Information.IsDBNull(data.Rows(0)("a_datemodified")), data.Rows(0)("a_datemodified"), Nothing)
                    consultation.OPDConsent1 = (data.Rows(0)("a_opdconsent1"))
                    consultation.OPDConsent2 = (data.Rows(0)("a_opdconsent2"))
                    consultation.isServed = (data.Rows(0)("a_isServed"))
                    consultation.ForInitialConsultation_ServerAssignCounter_ID = (data.Rows(0)("a_forinitialconsult_serverassigncounter_ID"))
                    consultation.FK_psPatRegisters = (data.Rows(0)("a_FK_psPatRegisters"))
                    consultation.FK_emdPatients = (data.Rows(0)("a_FK_emdPatients"))
                    consultation.Info_ID = (data.Rows(0)("a_info_id"))
                    consultation.ServerTransaction_ID = (data.Rows(0)("a_servertransaction_id"))
                    consultation.ServedCustomerID = (data.Rows(0)("a_servedcustomer_id"))
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = (data.Rows(0)("e_servertransaction_id"))
                    consultation.ServerTransaction.ServerAssignCounter_ID = (data.Rows(0)("e_serverassigncounter_id"))
                    consultation.ServerTransaction.CounterName = (data.Rows(0)("e_countername"))
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("f_serverassigncounter_ID"))
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = (data.Rows(0)("f_server_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = (data.Rows(0)("f_counter_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("h_counter_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = (data.Rows(0)("h_department"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = (data.Rows(0)("h_section"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("h_servicedescription"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("h_counterPrefix"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = (data.Rows(0)("h_icon"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = (data.Rows(0)("h_consultationView"))
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("h_consultationAddEdit"))
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = (data.Rows(0)("g_server_id"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = (data.Rows(0)("g_fullname"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("g_assigndepartment"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = (data.Rows(0)("g_prc"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = (data.Rows(0)("g_ptr"))
                    consultation.ServerTransaction.ServerAssignCounter.Server.S2No = (data.Rows(0)("g_s2"))
                    consultation.ServedCustomer = New ServedCustomer
                    consultation.ServedCustomer.ServedCustomer_ID = (data.Rows(0)("b_served_id"))
                    consultation.ServedCustomer.ServerTransaction_ID = (data.Rows(0)("b_servertransaction_id"))
                    consultation.ServedCustomer.CustomerAssginCounter_ID = (data.Rows(0)("b_customerassigncounter_id"))
                    consultation.ServedCustomer.DateTimeStart = If(Not Information.IsDBNull((data.Rows(0)("b_datetimeservedstart"))), data.Rows(0)("b_datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not Information.IsDBNull((data.Rows(0)("b_datetimeservedend"))), data.Rows(0)("b_datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = (data.Rows(0)("c_customerassigncounter_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = (data.Rows(0)("c_counter_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = (data.Rows(0)("c_customer_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = (data.Rows(0)("c_datetimequeued"))
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = (data.Rows(0)("c_priority"))
                    consultation.ServedCustomer.CustomerAssignCounter.Result = (data.Rows(0)("c_result"))
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = (data.Rows(0)("c_queuenumber"))
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = (data.Rows(0)("c_paymentmethod"))
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = (If(Not Information.IsDBNull((data.Rows(0)("c_notes"))), data.Rows(0)("c_notes"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = (If(Not Information.IsDBNull((data.Rows(0)("c_notedepartment"))), data.Rows(0)("c_notedepartment"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = (If(Not Information.IsDBNull((data.Rows(0)("c_notesection"))), data.Rows(0)("c_notesection"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = (data.Rows(0)("d_customer_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = (If(Not Information.IsDBNull((data.Rows(0)("d_fullname"))), data.Rows(0)("d_fullname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("d_firstname"))), data.Rows(0)("d_firstname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = (If(Not Information.IsDBNull((data.Rows(0)("d_middlename"))), data.Rows(0)("d_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = (If(Not Information.IsDBNull((data.Rows(0)("d_lastname"))), data.Rows(0)("d_lastname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = (If(Not Information.IsDBNull((data.Rows(0)("d_sex"))), data.Rows(0)("d_sex"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = (If(Not Information.IsDBNull((data.Rows(0)("d_birthdate"))), data.Rows(0)("d_birthdate"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("d_civilstatus"))), data.Rows(0)("d_civilstatus"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = (If(Not Information.IsDBNull((data.Rows(0)("d_address"))), data.Rows(0)("d_address"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("d_phonenumber"))), data.Rows(0)("d_phonenumber"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = (data.Rows(0)("d_dateofvisit"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("d_FK_emdPatients"))), data.Rows(0)("d_FK_emdPatients"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = (If(Not Information.IsDBNull((data.Rows(0)("d_info_id"))), data.Rows(0)("d_info_id"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = (data.Rows(0)("i_info_id"))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = (If(Not Information.IsDBNull((data.Rows(0)("i_firstname"))), data.Rows(0)("i_firstname"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = (If(Not Information.IsDBNull((data.Rows(0)("i_middlename"))), data.Rows(0)("i_middlename"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = (If(Not Information.IsDBNull((data.Rows(0)("i_sex"))), data.Rows(0)("i_sex"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = (If(Not Information.IsDBNull((data.Rows(0)("i_birthdate"))), data.Rows(0)("i_birthdate"), Nothing))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = (If(Not Information.IsDBNull((data.Rows(0)("i_civilstatus"))), data.Rows(0)("i_civilstatus"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = (If(Not Information.IsDBNull((data.Rows(0)("i_street"))), data.Rows(0)("i_street"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = (If(Not Information.IsDBNull((data.Rows(0)("i_barangay"))), data.Rows(0)("i_barangay"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = (If(Not Information.IsDBNull((data.Rows(0)("i_city"))), data.Rows(0)("i_city"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = (If(Not Information.IsDBNull((data.Rows(0)("i_phonenumber"))), data.Rows(0)("i_phonenumber"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = (If(Not Information.IsDBNull((data.Rows(0)("i_nationality"))), data.Rows(0)("i_nationality"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = (If(Not Information.IsDBNull((data.Rows(0)("i_picturelocation"))), data.Rows(0)("i_picturelocation"), ""))
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = (If(Not Information.IsDBNull((data.Rows(0)("i_FK_emdPatients"))), data.Rows(0)("i_FK_emdPatients"), Nothing))
                    consultation.ForInitialConsultation_ServerAssignCounter = New ServerAssignCounter
                    consultation.ForInitialConsultation_ServerAssignCounter.ServerAssignCounter_ID = (data.Rows(0)("j_serverassigncounter_ID"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server_ID = (data.Rows(0)("j_server_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter_ID = (data.Rows(0)("j_counter_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter = New Counter
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Counter_ID = (data.Rows(0)("l_counter_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Department = (data.Rows(0)("l_department"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Section = (data.Rows(0)("l_section"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.ServiceDescription = (data.Rows(0)("l_servicedescription"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.CounterPrefix = (data.Rows(0)("l_counterPrefix"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.Icon = (data.Rows(0)("l_icon"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationView = (data.Rows(0)("l_consultationView"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Counter.consultationAddEdit = (data.Rows(0)("l_consultationAddEdit"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server = New Server
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.Server_ID = (data.Rows(0)("k_server_id"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.FullName = (data.Rows(0)("k_fullname"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.AssignDepartment = (data.Rows(0)("k_assigndepartment"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.PRC = (data.Rows(0)("k_prc"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.PTR = (data.Rows(0)("k_ptr"))
                    consultation.ForInitialConsultation_ServerAssignCounter.Server.S2No = (data.Rows(0)("k_s2"))
                    Return consultation
                End If
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientFollowUpConsultationSchedules(infoID As Long) As List(Of FollowUpConsultation)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (GETDATE()) as 'Current' FROM  [dbo].[followupconsultation] as a
                                JOIN [dbo].[customervitals] as b on b.consultation_id = a.consultation_id
                                JOIN [wmmcqms].[servertransaction] as c on c.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as d on d.serverassigncounter_ID = c.serverassigncounter_id
                                JOIN [wmmcqms].[server] as e on e.server_id = d.server_id  WHERE b.info_id = @ID"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim followUpConsultations As New List(Of FollowUpConsultation)
                For Each row As DataRow In data.Rows
                    Dim followUPConsultation As New FollowUpConsultation
                    followUPConsultation.FollowUp_ID = row("")
                    followUPConsultation.Consultation_Date = row("")
                    followUPConsultation.FollowUp_ID = row("")
                    followUPConsultation.FollowUp_ID = row("")
                    followUPConsultation.FollowUp_ID = row("")
                    followUPConsultation.FollowUp_ID = row("")
                    followUPConsultation.FollowUp_ID = row("")
                    followUpConsultations.Add(followUPConsultation)
                Next
                Return followUpConsultations
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewConsultation(consultation As CustomerConsultation) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[customervitals] ([weight] ,[weightunit] ,[height] ,[heightunit] ,[systolic] ,[diastolic] ,[temperature] ,[pulserate] ,[respiratoryrate] ,[oxygen] ,[chiefcomplaint] ,[illnesshistory] ,[diagnosis] ,[doctorsorder] ,[FK_emdPatients] ,[servertransaction_id] ,[info_id]) VALUES
                               (@wgt ,@wgtunit ,@hgt ,@hgtunit ,@sys ,@dia ,@tmp ,@pr ,@rr ,@o2 ,@chiefcom ,@ihist ,@dgnosis ,@dorder ,@fkid ,@stid ,@inid)"
            cmd.Parameters.AddWithValue("@wgt", consultation.Weight)
            cmd.Parameters.AddWithValue("@wgtunit", consultation.WeightUnit.Trim)
            cmd.Parameters.AddWithValue("@hgt", consultation.Height)
            cmd.Parameters.AddWithValue("@hgtunit", consultation.HeightUnit.Trim)
            cmd.Parameters.AddWithValue("@sys", consultation.Systolic)
            cmd.Parameters.AddWithValue("@dia", consultation.Diastolic)
            cmd.Parameters.AddWithValue("@tmp", consultation.Temperature)
            cmd.Parameters.AddWithValue("@pr", consultation.PulseRate)
            cmd.Parameters.AddWithValue("@rr", consultation.RespiratoryRate)
            cmd.Parameters.AddWithValue("@o2", consultation.Oxygen)
            cmd.Parameters.AddWithValue("@chiefcom", consultation.ChiefComplaint.Trim)
            cmd.Parameters.AddWithValue("@ihist", consultation.IllnessHistory.Trim)
            cmd.Parameters.AddWithValue("@dgnosis", consultation.Diagnosis.Trim)
            cmd.Parameters.AddWithValue("@dorder", consultation.DoctorsOrder.Trim)
            cmd.Parameters.AddWithValue("@fkid", consultation.FK_emdPatients)
            cmd.Parameters.AddWithValue("@stid", consultation.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@inid", consultation.Info_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function DeleteConsultation(ID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [dbo].[customervitals] WHERE consultation_id = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function EditConsultation(consultation As CustomerConsultation) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [dbo].[customervitals] SET [weight] = @wgt ,[weightunit] = @wgtunit ,[height] = @hgt ,[heightunit] = @hgtunit ,[systolic] = @sys ,[diastolic] = @dia ,[temperature] = @tmp ,[pulserate] = @pr ,[respiratoryrate] = @rr ,[oxygen] = @o2 ,[pain] = @pain ,[painlocation] = @painloc ,[hypertension] = @hprtnsion ,[diabetes] = @diabts ,[asthma] = @astma ,[hearthdisease] = @hrtdis ,[arthritis] = @artris ,[cancer] = @cncr ,[tuberculosis] = @tb ,[stroke] = @strk ,[othermedicalhistory] = @othermedhis ,[allergies] = @allrgy ,[signsymptoms] = @signsymp ,[medicinetaken] = @medstkn ,[chiefcomplaint] = @chiefcom ,[illnesshistory] = @ihist ,[diagnosis] = @dgnosis ,[doctorsorder] = @dorder , [OPDConsent] = @opdcons,[datemodified] = GETDATE(), [findings] = @fnds, [copd] = @copd WHERE [consultation_id] = @ID"
            cmd.Parameters.AddWithValue("@wgt", consultation.Weight)
            cmd.Parameters.AddWithValue("@wgtunit", consultation.WeightUnit.Trim)
            cmd.Parameters.AddWithValue("@hgt", consultation.Height)
            cmd.Parameters.AddWithValue("@hgtunit", consultation.HeightUnit.Trim)
            cmd.Parameters.AddWithValue("@sys", consultation.Systolic)
            cmd.Parameters.AddWithValue("@dia", consultation.Diastolic)
            cmd.Parameters.AddWithValue("@tmp", consultation.Temperature)
            cmd.Parameters.AddWithValue("@pr", consultation.PulseRate)
            cmd.Parameters.AddWithValue("@rr", consultation.RespiratoryRate)
            cmd.Parameters.AddWithValue("@o2", consultation.Oxygen)
            cmd.Parameters.AddWithValue("@medstkn", consultation.MedicineTaken)
            cmd.Parameters.AddWithValue("@allrgy", consultation.Allergies)
            cmd.Parameters.AddWithValue("@signsymp", consultation.SignAndSymptoms)
            cmd.Parameters.AddWithValue("@pain", consultation.Pain)
            cmd.Parameters.AddWithValue("@painloc", consultation.PainLocation)
            cmd.Parameters.AddWithValue("@hprtnsion", consultation.Hypertension)
            cmd.Parameters.AddWithValue("@diabts", consultation.Diabetes)
            cmd.Parameters.AddWithValue("@astma", consultation.Asthma)
            cmd.Parameters.AddWithValue("@hrtdis", consultation.HeartDisease)
            cmd.Parameters.AddWithValue("@artris", consultation.Arthitis)
            cmd.Parameters.AddWithValue("@cncr", consultation.Cancer)
            cmd.Parameters.AddWithValue("@tb", consultation.Tuberculosis)
            cmd.Parameters.AddWithValue("@strk", consultation.Stroke)
            cmd.Parameters.AddWithValue("@copd", consultation.COPD)
            cmd.Parameters.AddWithValue("@othermedhis", consultation.othermedicalhistory)
            cmd.Parameters.AddWithValue("@chiefcom", consultation.ChiefComplaint.Trim)
            cmd.Parameters.AddWithValue("@ihist", consultation.IllnessHistory.Trim)
            cmd.Parameters.AddWithValue("@fnds", consultation.Findings.Trim)
            cmd.Parameters.AddWithValue("@dgnosis", consultation.Diagnosis.Trim)
            cmd.Parameters.AddWithValue("@dorder", If(Not IsNothing(consultation.DoctorsOrder), consultation.DoctorsOrder.Trim, ""))
            cmd.Parameters.AddWithValue("@opdcons", If(Not IsNothing(consultation.OPDConsent1), consultation.OPDConsent1.Trim, ""))
            cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SaveInitialConsultation(consultation As CustomerConsultation) As Boolean
        Try
            If consultation.Consultation_ID > 0 Then 'Update Initial Consultation Form
                Dim cmd As New SqlCommand
                cmd.CommandText = "UPDATE [dbo].[customervitals] SET [traigenurseonduty] = @tnod,[weight] = @wgt ,[weightunit] = @wgtunit ,[height] = @hgt ,[heightunit] = @hgtunit ,[systolic] = @sys ,[diastolic] = @dia ,[temperature] = @tmp ,[pulserate] = @pr ,[respiratoryrate] = @rr ,[oxygen] = @o2 ,[pain] = @pain ,[painlocation] = @painloc ,[hypertension] = @hprtnsion ,[diabetes] = @diabts ,[asthma] = @astma ,[hearthdisease] = @hrtdis ,[arthritis] = @artris ,[cancer] = @cncr ,[tuberculosis] = @tb ,[stroke] = @strk ,[othermedicalhistory] = @othermedhis ,[allergies] = @allrgy ,[signsymptoms] = @signsymp ,[medicinetaken] = @medstkn ,[chiefcomplaint] = @chiefcom ,[datemodified] = GETDATE() ,[FK_emdPatients] = @fkid ,[servertransaction_id] = @stid ,[info_id] = @inid ,[served_id] = @srid ,[OPDConsent] = @opdcons, [isFollowUpConsultation] = @ffcon, [tmpAssignCounter_id] = @tmpACID, [isEConsulta] = @econ, [copd] = @copd, [opdconsent2] = @opdcons2, [isHelee] = @helee, [referred_PK_psPersonalData] = @rfid WHERE consultation_id = @ID"
                cmd.Parameters.AddWithValue("@wgt", consultation.Weight)
                cmd.Parameters.AddWithValue("@wgtunit", consultation.WeightUnit.Trim)
                cmd.Parameters.AddWithValue("@hgt", consultation.Height)
                cmd.Parameters.AddWithValue("@hgtunit", consultation.HeightUnit.Trim)
                cmd.Parameters.AddWithValue("@sys", consultation.Systolic)
                cmd.Parameters.AddWithValue("@dia", consultation.Diastolic)
                cmd.Parameters.AddWithValue("@tmp", consultation.Temperature)
                cmd.Parameters.AddWithValue("@pr", consultation.PulseRate)
                cmd.Parameters.AddWithValue("@rr", consultation.RespiratoryRate)
                cmd.Parameters.AddWithValue("@o2", consultation.Oxygen)
                cmd.Parameters.AddWithValue("@medstkn", consultation.MedicineTaken)
                cmd.Parameters.AddWithValue("@allrgy", consultation.Allergies)
                cmd.Parameters.AddWithValue("@signsymp", consultation.SignAndSymptoms)
                cmd.Parameters.AddWithValue("@pain", consultation.Pain)
                cmd.Parameters.AddWithValue("@painloc", consultation.PainLocation)
                cmd.Parameters.AddWithValue("@hprtnsion", consultation.Hypertension)
                cmd.Parameters.AddWithValue("@diabts", consultation.Diabetes)
                cmd.Parameters.AddWithValue("@astma", consultation.Asthma)
                cmd.Parameters.AddWithValue("@hrtdis", consultation.HeartDisease)
                cmd.Parameters.AddWithValue("@artris", consultation.Arthitis)
                cmd.Parameters.AddWithValue("@cncr", consultation.Cancer)
                cmd.Parameters.AddWithValue("@tb", consultation.Tuberculosis)
                cmd.Parameters.AddWithValue("@strk", consultation.Stroke)
                cmd.Parameters.AddWithValue("@copd", consultation.COPD)
                cmd.Parameters.AddWithValue("@othermedhis", consultation.othermedicalhistory)
                cmd.Parameters.AddWithValue("@chiefcom", consultation.ChiefComplaint.Trim)
                cmd.Parameters.AddWithValue("@opdcons", If(Not IsNothing(consultation.OPDConsent1), consultation.OPDConsent1.Trim, ""))
                cmd.Parameters.AddWithValue("@opdcons2", If(Not IsNothing(consultation.OPDConsent2), consultation.OPDConsent2.Trim, ""))
                cmd.Parameters.AddWithValue("@tnod", If(Not IsNothing(consultation.TriageNurseOnDuty), consultation.TriageNurseOnDuty.Trim, ""))
                cmd.Parameters.AddWithValue("@fkid", consultation.FK_emdPatients)
                cmd.Parameters.AddWithValue("@stid", consultation.ServerTransaction_ID)
                cmd.Parameters.AddWithValue("@inid", consultation.Info_ID)
                cmd.Parameters.AddWithValue("@srid", consultation.ServedCustomer_ID)
                cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                cmd.Parameters.AddWithValue("@ffcon", consultation.isFollowUpConsultation)
                cmd.Parameters.AddWithValue("@rfid", consultation.ReferringConsulant_ID)
                cmd.Parameters.AddWithValue("@tmpACID", consultation.AssignConsultationCounter_ID)
                cmd.Parameters.AddWithValue("@econ", consultation.isEConsulta)
                cmd.Parameters.AddWithValue("@helee", consultation.isHealee)
                Return excecuteCommand(cmd)
            Else 'Create New Initial Consultation Form
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [dbo].[customervitals] 
                                    ([traigenurseonduty],[weight],[weightunit],[height],[heightunit],[systolic],[diastolic],[temperature],[pulserate],[respiratoryrate],[oxygen],[medicinetaken],[allergies],[signsymptoms],[pain],[painlocation],[hypertension],[diabetes],[asthma],[hearthdisease],[arthritis],[cancer],[tuberculosis],[stroke],[othermedicalhistory],[chiefcomplaint],[tempqueue],[pccConsultation],[OPDConsent],[isFollowUpConsultation],[FK_emdPatients],[servertransaction_id],[info_id],[served_id],[tmpAssignCounter_id],[isEConsulta],[copd],[opdconsent2],[isHelee],[referred_PK_psPersonalData]) 
                                    VALUES (@tnod,@wgt,@wgtunit,@hgt,@hgtunit,@sys,@dia,@tmp,@pr,@rr,@o2,@medstkn,@allrgy,@signsymp,@pain,@painloc,@hprtnsion,@diabts,@astma,@hrtdis,@artris,@cncr,@tb,@strk,@othermedhis,@chiefcom,1,1,@opdcons,@ffcon,@fkid,@stid,@inid,@srid,@tmpACID,@econ,@copd,@opdcons2,@helee,@rfid)"
                cmd.Parameters.AddWithValue("@wgt", consultation.Weight)
                cmd.Parameters.AddWithValue("@wgtunit", consultation.WeightUnit.Trim)
                cmd.Parameters.AddWithValue("@hgt", consultation.Height)
                cmd.Parameters.AddWithValue("@hgtunit", consultation.HeightUnit.Trim)
                cmd.Parameters.AddWithValue("@sys", consultation.Systolic)
                cmd.Parameters.AddWithValue("@dia", consultation.Diastolic)
                cmd.Parameters.AddWithValue("@tmp", consultation.Temperature)
                cmd.Parameters.AddWithValue("@pr", consultation.PulseRate)
                cmd.Parameters.AddWithValue("@rr", consultation.RespiratoryRate)
                cmd.Parameters.AddWithValue("@o2", consultation.Oxygen)
                cmd.Parameters.AddWithValue("@medstkn", consultation.MedicineTaken)
                cmd.Parameters.AddWithValue("@allrgy", consultation.Allergies)
                cmd.Parameters.AddWithValue("@signsymp", consultation.SignAndSymptoms)
                cmd.Parameters.AddWithValue("@pain", consultation.Pain)
                cmd.Parameters.AddWithValue("@painloc", consultation.PainLocation)
                cmd.Parameters.AddWithValue("@hprtnsion", consultation.Hypertension)
                cmd.Parameters.AddWithValue("@diabts", consultation.Diabetes)
                cmd.Parameters.AddWithValue("@astma", consultation.Asthma)
                cmd.Parameters.AddWithValue("@hrtdis", consultation.HeartDisease)
                cmd.Parameters.AddWithValue("@artris", consultation.Arthitis)
                cmd.Parameters.AddWithValue("@cncr", consultation.Cancer)
                cmd.Parameters.AddWithValue("@tb", consultation.Tuberculosis)
                cmd.Parameters.AddWithValue("@strk", consultation.Stroke)
                cmd.Parameters.AddWithValue("@copd", consultation.COPD)
                cmd.Parameters.AddWithValue("@othermedhis", consultation.othermedicalhistory)
                cmd.Parameters.AddWithValue("@chiefcom", consultation.ChiefComplaint.Trim)
                cmd.Parameters.AddWithValue("@opdcons", If(Not IsNothing(consultation.OPDConsent1), consultation.OPDConsent1.Trim, ""))
                cmd.Parameters.AddWithValue("@opdcons2", If(Not IsNothing(consultation.OPDConsent2), consultation.OPDConsent2.Trim, ""))
                cmd.Parameters.AddWithValue("@tnod", If(Not IsNothing(consultation.TriageNurseOnDuty), consultation.TriageNurseOnDuty.Trim, ""))
                cmd.Parameters.AddWithValue("@fkid", consultation.FK_emdPatients)
                cmd.Parameters.AddWithValue("@stid", consultation.ServerTransaction_ID)
                cmd.Parameters.AddWithValue("@inid", consultation.Info_ID)
                cmd.Parameters.AddWithValue("@srid", consultation.ServedCustomer_ID)
                cmd.Parameters.AddWithValue("@ffcon", consultation.isFollowUpConsultation)
                cmd.Parameters.AddWithValue("@rfid", consultation.ReferringConsulant_ID)
                cmd.Parameters.AddWithValue("@tmpACID", consultation.AssignConsultationCounter_ID)
                cmd.Parameters.AddWithValue("@econ", consultation.isEConsulta)
                cmd.Parameters.AddWithValue("@helee", consultation.isHealee)
                Return excecuteCommand(cmd)
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function GetCustomerVitalSummary(infoID As Long, fkEmdPatient As Long) As List(Of CustomerConsultation)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT TOP 10 weight, weightunit, height, heightunit, systolic, diastolic, temperature, pulserate, respiratoryrate, oxygen, datecreated, datemodified FROM customervitals WHERE (info_id = @ID " & qry & ") AND (dataType = 0 OR dataType = 1) ORDER BY consultation_id DESC"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim consultations As New List(Of CustomerConsultation)
                For Each row As DataRow In data.Rows
                    Dim consultation As New CustomerConsultation
                    consultation.Weight = row("weight")
                    consultation.WeightUnit = row("weightunit").ToString.Trim
                    consultation.Height = row("height")
                    consultation.HeightUnit = row("heightunit").ToString.Trim
                    consultation.Systolic = row("systolic")
                    consultation.Diastolic = row("diastolic")
                    consultation.Temperature = row("temperature")
                    consultation.PulseRate = row("pulserate")
                    consultation.RespiratoryRate = row("respiratoryrate")
                    consultation.Oxygen = row("oxygen")
                    consultation.DateCreated = If(Not IsDBNull(row("datecreated")), row("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(row("datemodified")), row("datemodified"), Nothing)
                    consultations.Add(consultation)
                Next
                Return consultations
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllCustomerConsultation(infoID As Long, fkEmdPatient As Long) As List(Of CustomerConsultation)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * FROM [customervitals] as a  JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id WHERE (a.info_id = @ID " & qry & ") ORDER BY a.consultation_id  DESC;"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim consultations As New List(Of CustomerConsultation)
                For Each row As DataRow In data.Rows
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = row("consultation_id")
                    consultation.Weight = If(Not IsDBNull(row("weight")), row("weight"), 0)
                    consultation.WeightUnit = If(Not IsDBNull(row("weightunit")), row("weightunit").ToString.Trim, "")
                    consultation.Height = If(Not IsDBNull(row("height")), row("height"), 0)
                    consultation.HeightUnit = If(Not IsDBNull(row("heightunit")), row("heightunit").ToString.Trim, "")
                    consultation.Systolic = If(Not IsDBNull(row("systolic")), row("systolic"), 0)
                    consultation.Diastolic = If(Not IsDBNull(row("diastolic")), row("diastolic"), 0)
                    consultation.Temperature = If(Not IsDBNull(row("temperature")), row("temperature"), 0)
                    consultation.PulseRate = If(Not IsDBNull(row("pulserate")), row("pulserate"), 0)
                    consultation.RespiratoryRate = If(Not IsDBNull(row("respiratoryrate")), row("respiratoryrate"), 0)
                    consultation.Oxygen = If(Not IsDBNull(row("oxygen")), row("oxygen"), 0)
                    consultation.ChiefComplaint = If(Not IsDBNull(row("chiefcomplaint")), row("chiefcomplaint").ToString.Trim, "")
                    consultation.IllnessHistory = If(Not IsDBNull(row("illnesshistory")), row("illnesshistory").ToString.Trim, "")
                    consultation.Diagnosis = If(Not IsDBNull(row("diagnosis")), row("diagnosis").ToString.Trim, "")
                    consultation.DoctorsOrder = If(Not IsDBNull(row("doctorsorder")), row("doctorsorder").ToString.Trim, "")
                    consultation.DateCreated = If(Not IsDBNull(row("datecreated")), row("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(row("datemodified")), row("datemodified"), Nothing)
                    consultation.FK_emdPatients = row("FK_emdPatients")
                    consultation.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServerTransaction.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.CounterName = row("countername")
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    consultations.Add(consultation)
                Next
                Return consultations
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllCustomerConsultationHistory(infoID As Long, fkEmdPatient As Long) As List(Of CustomerConsultation)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * 
                                FROM [dbo].[customervitals] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.served_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on b.customerassigncounter_id = c.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on c.customer_id = d.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on b.servertransaction_id = e.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on e.serverassigncounter_id = f.serverassigncounter_ID
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on d.info_id = i.info_id
                               WHERE (a.info_id = @inid " & qry & ")
                               ORDER BY a.consultation_id  DESC;"
            cmd.Parameters.AddWithValue("@inid", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim consultations As New List(Of CustomerConsultation)
                For Each row As DataRow In data.Rows
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = row("consultation_id")
                    consultation.Weight = If(Not IsDBNull(row("weight")), row("weight"), 0)
                    consultation.WeightUnit = If(Not IsDBNull(row("weightunit")), row("weightunit").ToString.Trim, "")
                    consultation.Height = If(Not IsDBNull(row("height")), row("height"), 0)
                    consultation.HeightUnit = If(Not IsDBNull(row("heightunit")), row("heightunit").ToString.Trim, "")
                    consultation.Systolic = If(Not IsDBNull(row("systolic")), row("systolic"), 0)
                    consultation.Diastolic = If(Not IsDBNull(row("diastolic")), row("diastolic"), 0)
                    consultation.Temperature = If(Not IsDBNull(row("temperature")), row("temperature"), 0)
                    consultation.PulseRate = If(Not IsDBNull(row("pulserate")), row("pulserate"), 0)
                    consultation.RespiratoryRate = If(Not IsDBNull(row("respiratoryrate")), row("respiratoryrate"), 0)
                    consultation.Oxygen = If(Not IsDBNull(row("oxygen")), row("oxygen"), 0)
                    consultation.Pain = If(Not IsDBNull(row("pain")), row("pain").ToString.Trim, "")
                    consultation.PainLocation = If(Not IsDBNull(row("painlocation")), row("painlocation").ToString.Trim, "")
                    consultation.Hypertension = If(row("hypertension") > 0, True, False)
                    consultation.Diabetes = If(row("diabetes") > 0, True, False)
                    consultation.Asthma = If(row("asthma") > 0, True, False)
                    consultation.HeartDisease = If(row("hearthdisease") > 0, True, False)
                    consultation.Arthitis = If(row("arthritis") > 0, True, False)
                    consultation.Cancer = If(row("cancer") > 0, True, False)
                    consultation.Tuberculosis = If(row("tuberculosis") > 0, True, False)
                    consultation.Stroke = If(row("stroke") > 0, True, False)
                    consultation.COPD = If(row("copd") > 0, True, False)
                    consultation.TransferredReferred = If(Not IsDBNull(row("transferredreferred")), row("transferredreferred"), 0)
                    consultation.RefusedAdmission = If(Not IsDBNull(row("refusedadmission")), row("refusedadmission"), 0)
                    consultation.ERDeath = If(Not IsDBNull(row("erdeath")), row("erdeath"), 0)
                    consultation.Discharged = If(Not IsDBNull(row("discharged")), row("discharged"), 0)
                    consultation.ForFollowUp = If(Not IsDBNull(row("forfollowup")), row("forfollowup"), 0)
                    consultation.Absconed = If(Not IsDBNull(row("absconed")), row("absconed"), 0)
                    consultation.HAMADAMA = If(Not IsDBNull(row("hamadam")), row("hamadam"), 0)
                    consultation.DOA = If(Not IsDBNull(row("doa")), row("doa"), 0)
                    consultation.Admitted = If(Not IsDBNull(row("admitted")), row("admitted"), 0)
                    consultation.RoomAdmitted = If(Not IsDBNull(row("admittedroom")), row("admittedroom"), "")
                    consultation.WardAdmitted = If(Not IsDBNull(row("admittedward")), row("admittedward"), "")
                    consultation.AdmittedProgressNote = If(Not IsDBNull(row("admissionprogressnote")), row("admissionprogressnote"), "")
                    consultation.AdmittedDoctorsOrder = If(Not IsDBNull(row("admissiondoctororder")), row("admissiondoctororder"), "")
                    consultation.AdmittedRemarks = If(Not IsDBNull(row("admissionremarks")), row("admissionremarks"), "")
                    consultation.othermedicalhistory = If(Not IsDBNull(row("othermedicalhistory")), row("othermedicalhistory").ToString.Trim, "")
                    consultation.Allergies = If(Not IsDBNull(row("allergies")), row("allergies").ToString.Trim, "")
                    consultation.SignAndSymptoms = If(Not IsDBNull(row("signsymptoms")), row("signsymptoms").ToString.Trim, "")
                    consultation.MedicineTaken = If(Not IsDBNull(row("medicinetaken")), row("medicinetaken").ToString.Trim, "")
                    consultation.ChiefComplaint = If(Not IsDBNull(row("chiefcomplaint")), row("chiefcomplaint").ToString.Trim, "")
                    consultation.IllnessHistory = If(Not IsDBNull(row("illnesshistory")), row("illnesshistory").ToString.Trim, "")
                    consultation.Findings = If(Not IsDBNull(row("findings")), row("findings").ToString.Trim, "")
                    consultation.Diagnosis = If(Not IsDBNull(row("diagnosis")), row("diagnosis").ToString.Trim, "")
                    consultation.DoctorsOrder = If(Not IsDBNull(row("doctorsorder")), row("doctorsorder").ToString.Trim, "")
                    consultation.tempQueue = If(row("tempqueue") > 0, True, False)
                    consultation.PccConsultation = If(row("pccConsultation") > 0, True, False)
                    consultation.isFollowUpConsultation = If(row("isFollowUpConsultation") > 0, True, False)
                    consultation.isEConsulta = If(row("isEConsulta") > 0, True, False)
                    consultation.OPDConsent1 = If(Not IsDBNull(row("opdconsent")), row("opdconsent").ToString.Trim, "")
                    consultation.OPDConsent2 = If(Not IsDBNull(row("opdconsent2")), row("opdconsent2").ToString.Trim, "")
                    consultation.TriageNurseOnDuty = If(Not IsDBNull(row("traigenurseonduty")), row("traigenurseonduty").ToString.Trim, "")
                    consultation.DateCreated = If(Not IsDBNull(row("datecreated")), row("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(row("datemodified")), row("datemodified"), Nothing)
                    consultation.ReferringConsulant_ID = If(Not IsDBNull(row("referred_PK_psPersonalData")), row("referred_PK_psPersonalData"), 0)
                    consultation.FK_emdPatients = row("FK_emdPatients")
                    consultation.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServedCustomer_ID = data.Rows(0)("served_id")
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServerTransaction.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.CounterName = row("countername")
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterType = row("countertype")
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname1")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = If(Not IsDBNull(row("prc")), row("prc"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = If(Not IsDBNull(row("ptr")), row("ptr"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.Specialization = If(Not IsDBNull(row("specializaton")), row("specializaton"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AccountType = row("accountType")
                    consultation.ServedCustomer = New ServedCustomer()
                    consultation.ServedCustomer.ServedCustomer_ID = row("server_id")
                    consultation.ServedCustomer.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServedCustomer.CustomerAssginCounter_ID = row("customerassigncounter_id")
                    consultation.ServedCustomer.DateTimeStart = If(Not IsDBNull(row("datetimeservedstart")), row("datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row("datetimeservedend")), row("datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = row("customerassigncounter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = row("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = row("datetimequeued")
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = row("priority")
                    consultation.ServedCustomer.CustomerAssignCounter.Result = row("result")
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = row("queuenumber")
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = row("paymentmethod")
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = If(Not IsDBNull(row("notes")), row("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(row("notedepartment")), row("notedepartment"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(row("notesection")), row("notesection"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = If(Not IsDBNull(row("notes")), row("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = row("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = If(Not IsDBNull(row("fullname")), row("fullname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = If(Not IsDBNull(row("address")), row("address"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = row("dateofvisit")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = If(Not IsDBNull(row("info_id")), row("info_id"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = row("info_id2")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = If(Not IsDBNull(row("firstname2")), row("firstname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = If(Not IsDBNull(row("middlename2")), row("middlename2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = If(Not IsDBNull(row("lastname2")), row("lastname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = If(Not IsDBNull(row("sex1")), row("sex1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(row("birthdate1")), row("birthdate1"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(row("phonenumber1")), row("phonenumber1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = If(Not IsDBNull(row("nationality")), row("nationality"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = If(Not IsDBNull(row("email")), row("email"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), Nothing)
                    consultation.Diagnostics = New Diagnostics
                    Dim diagnosticController As New DiagnosticsController
                    consultation.Diagnostics = diagnosticController.GetPatientCertainDiagnostics_Consultation(consultation.Consultation_ID)
                    consultation.Prescriptions = New List(Of Prescription)
                    Dim prescriptionController As New PrescriptionController
                    consultation.Prescriptions = prescriptionController.GetPatientPrescribeMeds_Consulation(consultation.Consultation_ID)
                    consultations.Add(consultation)
                    consultation.FollowUpConsultation = New List(Of FollowUpConsultation)
                    Dim followupController As New FollowUpConsultationController
                    consultation.FollowUpConsultation = followupController.GetCertainConsultations_FollowUpConsultations(consultation.Consultation_ID)
                    consultation.ERTraigeForm = Me.GetPatientERCharts(consultation)
                    consultation.ERDoctorsOrder = Me.GetPatientDoctorOrder(consultation)
                    consultation.NurseNotes = Me.GetPatientNurseNotes(consultation)
                    consultation.ProgressNotes = Me.GetProgressNotes(consultation.Consultation_ID)
                    If (consultation.ReferringConsulant_ID > 0) Then
                        Dim apiController As New APIController
                        consultation.ReferringConsultant = apiController.FindCertainDoctor(consultation.ReferringConsulant_ID)
                    End If

                Next
                Return consultations
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertianCustomerInitialConsultation(infoID As Long, fkEmdPatient As Long) As CustomerConsultation
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * 
                                FROM [dbo].[customervitals] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.served_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on b.customerassigncounter_id = c.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on c.customer_id = d.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on b.servertransaction_id = e.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on e.serverassigncounter_id = f.serverassigncounter_ID
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on d.info_id = i.info_id
                               WHERE (a.info_id = @inid " & qry & ") AND a.pccConsultation = 1 and a.tempqueue = 1 and CONVERT(date,a.datecreated) = CONVERT(date,GETDATE())
                               ORDER BY a.consultation_id  DESC;"
            cmd.Parameters.AddWithValue("@inid", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = data.Rows(0)("consultation_id")
                    consultation.Weight = If(Not IsDBNull(data.Rows(0)("weight")), data.Rows(0)("weight"), 0)
                    consultation.WeightUnit = If(Not IsDBNull(data.Rows(0)("weightunit")), data.Rows(0)("weightunit").ToString.Trim, "")
                    consultation.Height = If(Not IsDBNull(data.Rows(0)("height")), data.Rows(0)("height"), 0)
                    consultation.HeightUnit = If(Not IsDBNull(data.Rows(0)("heightunit")), data.Rows(0)("heightunit").ToString.Trim, "")
                    consultation.Systolic = If(Not IsDBNull(data.Rows(0)("systolic")), data.Rows(0)("systolic"), 0)
                    consultation.Diastolic = If(Not IsDBNull(data.Rows(0)("diastolic")), data.Rows(0)("diastolic"), 0)
                    consultation.Temperature = If(Not IsDBNull(data.Rows(0)("temperature")), data.Rows(0)("temperature"), 0)
                    consultation.PulseRate = If(Not IsDBNull(data.Rows(0)("pulserate")), data.Rows(0)("pulserate"), 0)
                    consultation.RespiratoryRate = If(Not IsDBNull(data.Rows(0)("respiratoryrate")), data.Rows(0)("respiratoryrate"), 0)
                    consultation.Oxygen = If(Not IsDBNull(data.Rows(0)("oxygen")), data.Rows(0)("oxygen"), 0)
                    consultation.Pain = If(Not IsDBNull(data.Rows(0)("pain")), data.Rows(0)("pain").ToString.Trim, "")
                    consultation.PainLocation = If(Not IsDBNull(data.Rows(0)("painlocation")), data.Rows(0)("painlocation").ToString.Trim, "")
                    consultation.Hypertension = If(data.Rows(0)("hypertension") > 0, True, False)
                    consultation.Diabetes = If(data.Rows(0)("diabetes") > 0, True, False)
                    consultation.Asthma = If(data.Rows(0)("asthma") > 0, True, False)
                    consultation.HeartDisease = If(data.Rows(0)("hearthdisease") > 0, True, False)
                    consultation.Arthitis = If(data.Rows(0)("arthritis") > 0, True, False)
                    consultation.Cancer = If(data.Rows(0)("cancer") > 0, True, False)
                    consultation.Tuberculosis = If(data.Rows(0)("tuberculosis") > 0, True, False)
                    consultation.Stroke = If(data.Rows(0)("stroke") > 0, True, False)
                    consultation.COPD = If(data.Rows(0)("copd") > 0, True, False)
                    consultation.othermedicalhistory = If(Not IsDBNull(data.Rows(0)("othermedicalhistory")), data.Rows(0)("othermedicalhistory").ToString.Trim, "")
                    consultation.Allergies = If(Not IsDBNull(data.Rows(0)("allergies")), data.Rows(0)("allergies").ToString.Trim, "")
                    consultation.SignAndSymptoms = If(Not IsDBNull(data.Rows(0)("signsymptoms")), data.Rows(0)("signsymptoms").ToString.Trim, "")
                    consultation.MedicineTaken = If(Not IsDBNull(data.Rows(0)("medicinetaken")), data.Rows(0)("medicinetaken").ToString.Trim, "")
                    consultation.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("chiefcomplaint")), data.Rows(0)("chiefcomplaint").ToString.Trim, "")
                    consultation.IllnessHistory = If(Not IsDBNull(data.Rows(0)("illnesshistory")), data.Rows(0)("illnesshistory").ToString.Trim, "")
                    consultation.Diagnosis = If(Not IsDBNull(data.Rows(0)("diagnosis")), data.Rows(0)("diagnosis").ToString.Trim, "")
                    consultation.DoctorsOrder = If(Not IsDBNull(data.Rows(0)("doctorsorder")), data.Rows(0)("doctorsorder").ToString.Trim, "")
                    consultation.tempQueue = If(data.Rows(0)("tempqueue") > 0, True, False)
                    consultation.PccConsultation = If(data.Rows(0)("pccConsultation") > 0, True, False)
                    consultation.OPDConsent1 = If(Not IsDBNull(data.Rows(0)("opdconsent")), data.Rows(0)("opdconsent").ToString.Trim, "")
                    consultation.OPDConsent2 = If(Not IsDBNull(data.Rows(0)("opdconsent2")), data.Rows(0)("opdconsent2").ToString.Trim, "")
                    consultation.TriageNurseOnDuty = If(Not IsDBNull(data.Rows(0)("traigenurseonduty")), data.Rows(0)("traigenurseonduty").ToString.Trim, "")
                    consultation.isFollowUpConsultation = If(Not IsDBNull(data.Rows(0)("isFollowUpConsultation")), data.Rows(0)("isFollowUpConsultation").ToString.Trim, "")
                    consultation.isEConsulta = If(Not IsDBNull(data.Rows(0)("isEConsulta")), data.Rows(0)("isEConsulta").ToString.Trim, False)
                    consultation.isHealee = If(Not IsDBNull(data.Rows(0)("isHelee")), data.Rows(0)("isHelee").ToString.Trim, False)
                    consultation.DateCreated = If(Not IsDBNull(data.Rows(0)("datecreated")), data.Rows(0)("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(data.Rows(0)("datemodified")), data.Rows(0)("datemodified"), Nothing)
                    consultation.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    consultation.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServedCustomer_ID = data.Rows(0)("served_id")
                    consultation.AssignConsultationCounter_ID = If(Not IsDBNull(data.Rows(0)("tmpAssignCounter_id")), data.Rows(0)("tmpAssignCounter_id"), 0)
                    consultation.ReferringConsulant_ID = If(Not IsDBNull(data.Rows(0)("referred_PK_psPersonalData")), data.Rows(0)("referred_PK_psPersonalData"), 0)
                    If (consultation.AssignConsultationCounter_ID > 0) Then
                        Dim serverAssignCounterController As New ServerAssignCounterController
                        consultation.ServerAssignCounter = serverAssignCounterController.GetCertainServerCertainAssignCounter(consultation.AssignConsultationCounter_ID)
                    End If
                    If (consultation.ReferringConsulant_ID > 0) Then
                        Dim apiController As New APIController
                        consultation.ReferringConsultant = apiController.FindCertainDoctor(consultation.ReferringConsulant_ID)
                    End If
                    Return consultation
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function


    Public Function GetCertainPatientConsultationsPerDoctor(infoID As Long, fkEmdPatient As Long, serverID As Long) As List(Of CustomerConsultation)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * 
                                FROM [dbo].[customervitals] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.served_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on b.customerassigncounter_id = c.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on c.customer_id = d.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on b.servertransaction_id = e.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on e.serverassigncounter_id = f.serverassigncounter_ID
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on d.info_id = i.info_id
                               WHERE (a.info_id = @inid " & qry & ") AND (g.server_id = @srid)
                               ORDER BY a.consultation_id  DESC;"
            cmd.Parameters.AddWithValue("@inid", infoID)
            cmd.Parameters.AddWithValue("@srid", serverID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim consultations As New List(Of CustomerConsultation)
                For Each row As DataRow In data.Rows
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = row("consultation_id")
                    consultation.Weight = If(Not IsDBNull(row("weight")), row("weight"), 0)
                    consultation.WeightUnit = If(Not IsDBNull(row("weightunit")), row("weightunit").ToString.Trim, "")
                    consultation.Height = If(Not IsDBNull(row("height")), row("height"), 0)
                    consultation.HeightUnit = If(Not IsDBNull(row("heightunit")), row("heightunit").ToString.Trim, "")
                    consultation.Systolic = If(Not IsDBNull(row("systolic")), row("systolic"), 0)
                    consultation.Diastolic = If(Not IsDBNull(row("diastolic")), row("diastolic"), 0)
                    consultation.Temperature = If(Not IsDBNull(row("temperature")), row("temperature"), 0)
                    consultation.PulseRate = If(Not IsDBNull(row("pulserate")), row("pulserate"), 0)
                    consultation.RespiratoryRate = If(Not IsDBNull(row("respiratoryrate")), row("respiratoryrate"), 0)
                    consultation.Oxygen = If(Not IsDBNull(row("oxygen")), row("oxygen"), 0)
                    consultation.Pain = If(Not IsDBNull(row("pain")), row("pain").ToString.Trim, "")
                    consultation.PainLocation = If(Not IsDBNull(row("painlocation")), row("painlocation").ToString.Trim, "")
                    consultation.Hypertension = If(row("hypertension") > 0, True, False)
                    consultation.Diabetes = If(row("diabetes") > 0, True, False)
                    consultation.Asthma = If(row("asthma") > 0, True, False)
                    consultation.HeartDisease = If(row("hearthdisease") > 0, True, False)
                    consultation.Arthitis = If(row("arthritis") > 0, True, False)
                    consultation.Cancer = If(row("cancer") > 0, True, False)
                    consultation.Tuberculosis = If(row("tuberculosis") > 0, True, False)
                    consultation.Stroke = If(row("stroke") > 0, True, False)
                    consultation.COPD = If(row("copd") > 0, True, False)
                    consultation.TransferredReferred = If(Not IsDBNull(row("transferredreferred")), row("transferredreferred"), 0)
                    consultation.RefusedAdmission = If(Not IsDBNull(row("refusedadmission")), row("refusedadmission"), 0)
                    consultation.ERDeath = If(Not IsDBNull(row("erdeath")), row("erdeath"), 0)
                    consultation.Discharged = If(Not IsDBNull(row("discharged")), row("discharged"), 0)
                    consultation.ForFollowUp = If(Not IsDBNull(row("forfollowup")), row("forfollowup"), 0)
                    consultation.Absconed = If(Not IsDBNull(row("absconed")), row("absconed"), 0)
                    consultation.HAMADAMA = If(Not IsDBNull(row("hamadam")), row("hamadam"), 0)
                    consultation.DOA = If(Not IsDBNull(row("doa")), row("doa"), 0)
                    consultation.Admitted = If(Not IsDBNull(row("admitted")), row("admitted"), 0)
                    consultation.RoomAdmitted = If(Not IsDBNull(row("admittedroom")), row("admittedroom"), "")
                    consultation.WardAdmitted = If(Not IsDBNull(row("admittedward")), row("admittedward"), "")
                    consultation.AdmittedProgressNote = If(Not IsDBNull(row("admissionprogressnote")), row("admissionprogressnote"), "")
                    consultation.AdmittedDoctorsOrder = If(Not IsDBNull(row("admissiondoctororder")), row("admissiondoctororder"), "")
                    consultation.AdmittedRemarks = If(Not IsDBNull(row("admissionremarks")), row("admissionremarks"), "")
                    consultation.othermedicalhistory = If(Not IsDBNull(row("othermedicalhistory")), row("othermedicalhistory").ToString.Trim, "")
                    consultation.Allergies = If(Not IsDBNull(row("allergies")), row("allergies").ToString.Trim, "")
                    consultation.SignAndSymptoms = If(Not IsDBNull(row("signsymptoms")), row("signsymptoms").ToString.Trim, "")
                    consultation.MedicineTaken = If(Not IsDBNull(row("medicinetaken")), row("medicinetaken").ToString.Trim, "")
                    consultation.ChiefComplaint = If(Not IsDBNull(row("chiefcomplaint")), row("chiefcomplaint").ToString.Trim, "")
                    consultation.IllnessHistory = If(Not IsDBNull(row("illnesshistory")), row("illnesshistory").ToString.Trim, "")
                    consultation.Findings = If(Not IsDBNull(row("findings")), row("findings").ToString.Trim, "")
                    consultation.Diagnosis = If(Not IsDBNull(row("diagnosis")), row("diagnosis").ToString.Trim, "")
                    consultation.DoctorsOrder = If(Not IsDBNull(row("doctorsorder")), row("doctorsorder").ToString.Trim, "")
                    consultation.tempQueue = If(row("tempqueue") > 0, True, False)
                    consultation.PccConsultation = If(row("pccConsultation") > 0, True, False)
                    consultation.isEConsulta = If(row("isEConsulta") > 0, True, False)
                    consultation.isFollowUpConsultation = If(row("isFollowUpConsultation") > 0, True, False)
                    consultation.OPDConsent1 = If(Not IsDBNull(row("opdconsent")), row("opdconsent").ToString.Trim, "")
                    consultation.OPDConsent2 = If(Not IsDBNull(row("opdconsent2")), row("opdconsent2").ToString.Trim, "")
                    consultation.DateCreated = If(Not IsDBNull(row("datecreated")), row("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(row("datemodified")), row("datemodified"), Nothing)
                    consultation.FK_emdPatients = row("FK_emdPatients")
                    consultation.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServedCustomer_ID = row("served_id")
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServerTransaction.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.CounterName = row("countername")
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterType = row("countertype")
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname1")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = If(Not IsDBNull(row("prc")), row("prc"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = If(Not IsDBNull(row("ptr")), row("ptr"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.Specialization = If(Not IsDBNull(row("specializaton")), row("specializaton"), "")
                    consultation.ServedCustomer = New ServedCustomer()
                    consultation.ServedCustomer.ServedCustomer_ID = row("server_id")
                    consultation.ServedCustomer.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServedCustomer.CustomerAssginCounter_ID = row("customerassigncounter_id")
                    consultation.ServedCustomer.DateTimeStart = If(Not IsDBNull(row("datetimeservedstart")), row("datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row("datetimeservedend")), row("datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = row("customerassigncounter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = row("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = row("datetimequeued")
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = row("priority")
                    consultation.ServedCustomer.CustomerAssignCounter.Result = row("result")
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = row("queuenumber")
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = row("paymentmethod")
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = If(Not IsDBNull(row("notes")), row("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(row("notedepartment")), row("notedepartment"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(row("notesection")), row("notesection"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = If(Not IsDBNull(row("notes")), row("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = row("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = If(Not IsDBNull(row("fullname")), row("fullname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = If(Not IsDBNull(row("address")), row("address"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = row("dateofvisit")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = If(Not IsDBNull(row("info_id")), row("info_id"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = row("info_id2")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = If(Not IsDBNull(row("firstname2")), row("firstname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = If(Not IsDBNull(row("middlename2")), row("middlename2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = If(Not IsDBNull(row("lastname2")), row("lastname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = If(Not IsDBNull(row("sex1")), row("sex1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(row("birthdate1")), row("birthdate1"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(row("phonenumber1")), row("phonenumber1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = If(Not IsDBNull(row("nationality")), row("nationality"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = If(Not IsDBNull(row("email")), row("email"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), Nothing)
                    consultation.Diagnostics = New Diagnostics
                    Dim diagnosticController As New DiagnosticsController
                    consultation.Diagnostics = diagnosticController.GetPatientCertainDiagnostics_Consultation(consultation.Consultation_ID)
                    consultation.Prescriptions = New List(Of Prescription)
                    Dim prescriptionController As New PrescriptionController
                    consultation.Prescriptions = prescriptionController.GetPatientPrescribeMeds_Consulation(consultation.Consultation_ID)
                    consultations.Add(consultation)
                    consultation.FollowUpConsultation = New List(Of FollowUpConsultation)
                    Dim followupController As New FollowUpConsultationController
                    consultation.FollowUpConsultation = followupController.GetCertainConsultations_FollowUpConsultations(consultation.Consultation_ID)
                Next
                Return consultations
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientPCCConsultations(infoID As Long, fkEmdPatient As Long) As List(Of CustomerConsultation)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * 
                                FROM [dbo].[customervitals] as a
                                JOIN [wmmcqms].[servedcustomer] as b on a.served_id = b.served_id
                                JOIN [wmmcqms].[customerassigncounter] as c on b.customerassigncounter_id = c.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as d on c.customer_id = d.customer_id
                                JOIN [wmmcqms].[servertransaction] as e on b.servertransaction_id = e.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as f on e.serverassigncounter_id = f.serverassigncounter_ID
                                JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                                JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                                JOIN [dbo].[customerinfo] as i on d.info_id = i.info_id
                               WHERE (a.info_id = @inid " & qry & ") AND (a.pccConsultation = 1)
                               ORDER BY a.consultation_id  DESC;"
            cmd.Parameters.AddWithValue("@inid", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim consultations As New List(Of CustomerConsultation)
                For Each row As DataRow In data.Rows
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = row("consultation_id")
                    consultation.Weight = If(Not IsDBNull(row("weight")), row("weight"), 0)
                    consultation.WeightUnit = If(Not IsDBNull(row("weightunit")), row("weightunit").ToString.Trim, "")
                    consultation.Height = If(Not IsDBNull(row("height")), row("height"), 0)
                    consultation.HeightUnit = If(Not IsDBNull(row("heightunit")), row("heightunit").ToString.Trim, "")
                    consultation.Systolic = If(Not IsDBNull(row("systolic")), row("systolic"), 0)
                    consultation.Diastolic = If(Not IsDBNull(row("diastolic")), row("diastolic"), 0)
                    consultation.Temperature = If(Not IsDBNull(row("temperature")), row("temperature"), 0)
                    consultation.PulseRate = If(Not IsDBNull(row("pulserate")), row("pulserate"), 0)
                    consultation.RespiratoryRate = If(Not IsDBNull(row("respiratoryrate")), row("respiratoryrate"), 0)
                    consultation.Oxygen = If(Not IsDBNull(row("oxygen")), row("oxygen"), 0)
                    consultation.Pain = If(Not IsDBNull(row("pain")), row("pain").ToString.Trim, "")
                    consultation.PainLocation = If(Not IsDBNull(row("painlocation")), row("painlocation").ToString.Trim, "")
                    consultation.Hypertension = If(row("hypertension") > 0, True, False)
                    consultation.Diabetes = If(row("diabetes") > 0, True, False)
                    consultation.Asthma = If(row("asthma") > 0, True, False)
                    consultation.HeartDisease = If(row("hearthdisease") > 0, True, False)
                    consultation.Arthitis = If(row("arthritis") > 0, True, False)
                    consultation.Cancer = If(row("cancer") > 0, True, False)
                    consultation.Tuberculosis = If(row("tuberculosis") > 0, True, False)
                    consultation.Stroke = If(row("stroke") > 0, True, False)
                    consultation.COPD = If(row("copd") > 0, True, False)
                    consultation.TransferredReferred = If(Not IsDBNull(row("transferredreferred")), row("transferredreferred"), 0)
                    consultation.RefusedAdmission = If(Not IsDBNull(row("refusedadmission")), row("refusedadmission"), 0)
                    consultation.ERDeath = If(Not IsDBNull(row("erdeath")), row("erdeath"), 0)
                    consultation.Discharged = If(Not IsDBNull(row("discharged")), row("discharged"), 0)
                    consultation.ForFollowUp = If(Not IsDBNull(row("forfollowup")), row("forfollowup"), 0)
                    consultation.Absconed = If(Not IsDBNull(row("absconed")), row("absconed"), 0)
                    consultation.HAMADAMA = If(Not IsDBNull(row("hamadam")), row("hamadam"), 0)
                    consultation.DOA = If(Not IsDBNull(row("doa")), row("doa"), 0)
                    consultation.Admitted = If(Not IsDBNull(row("admitted")), row("admitted"), 0)
                    consultation.RoomAdmitted = If(Not IsDBNull(row("admittedroom")), row("admittedroom"), "")
                    consultation.WardAdmitted = If(Not IsDBNull(row("admittedward")), row("admittedward"), "")
                    consultation.AdmittedProgressNote = If(Not IsDBNull(row("admissionprogressnote")), row("admissionprogressnote"), "")
                    consultation.AdmittedDoctorsOrder = If(Not IsDBNull(row("admissiondoctororder")), row("admissiondoctororder"), "")
                    consultation.AdmittedRemarks = If(Not IsDBNull(row("admissionremarks")), row("admissionremarks"), "")
                    consultation.othermedicalhistory = If(Not IsDBNull(row("othermedicalhistory")), row("othermedicalhistory").ToString.Trim, "")
                    consultation.Allergies = If(Not IsDBNull(row("allergies")), row("allergies").ToString.Trim, "")
                    consultation.SignAndSymptoms = If(Not IsDBNull(row("signsymptoms")), row("signsymptoms").ToString.Trim, "")
                    consultation.MedicineTaken = If(Not IsDBNull(row("medicinetaken")), row("medicinetaken").ToString.Trim, "")
                    consultation.ChiefComplaint = If(Not IsDBNull(row("chiefcomplaint")), row("chiefcomplaint").ToString.Trim, "")
                    consultation.IllnessHistory = If(Not IsDBNull(row("illnesshistory")), row("illnesshistory").ToString.Trim, "")
                    consultation.Findings = If(Not IsDBNull(row("findings")), row("findings").ToString.Trim, "")
                    consultation.Diagnosis = If(Not IsDBNull(row("diagnosis")), row("diagnosis").ToString.Trim, "")
                    consultation.DoctorsOrder = If(Not IsDBNull(row("doctorsorder")), row("doctorsorder").ToString.Trim, "")
                    consultation.tempQueue = If(row("tempqueue") > 0, True, False)
                    consultation.PccConsultation = If(row("pccConsultation") > 0, True, False)
                    consultation.isFollowUpConsultation = If(row("isFollowUpConsultation") > 0, True, False)
                    consultation.isEConsulta = If(row("isEConsulta") > 0, True, False)
                    consultation.OPDConsent1 = If(Not IsDBNull(row("opdconsent")), row("opdconsent").ToString.Trim, "")
                    consultation.DateCreated = If(Not IsDBNull(row("datecreated")), row("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(row("datemodified")), row("datemodified"), Nothing)
                    consultation.FK_emdPatients = row("FK_emdPatients")
                    consultation.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServedCustomer_ID = row("served_id")
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServerTransaction.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.CounterName = row("countername")
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterType = row("countertype")
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname1")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = If(Not IsDBNull(row("prc")), row("prc"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = If(Not IsDBNull(row("ptr")), row("ptr"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.Specialization = If(Not IsDBNull(row("specializaton")), row("specializaton"), "")
                    consultation.ServedCustomer = New ServedCustomer()
                    consultation.ServedCustomer.ServedCustomer_ID = row("server_id")
                    consultation.ServedCustomer.ServerTransaction_ID = row("servertransaction_id")
                    consultation.ServedCustomer.CustomerAssginCounter_ID = row("customerassigncounter_id")
                    consultation.ServedCustomer.DateTimeStart = If(Not IsDBNull(row("datetimeservedstart")), row("datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row("datetimeservedend")), row("datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = row("customerassigncounter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = row("counter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = row("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = row("datetimequeued")
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = row("priority")
                    consultation.ServedCustomer.CustomerAssignCounter.Result = row("result")
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = row("queuenumber")
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = row("paymentmethod")
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = If(Not IsDBNull(row("notes")), row("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(row("notedepartment")), row("notedepartment"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(row("notesection")), row("notesection"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = If(Not IsDBNull(row("notes")), row("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = row("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = If(Not IsDBNull(row("fullname")), row("fullname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = If(Not IsDBNull(row("address")), row("address"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = row("dateofvisit")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = If(Not IsDBNull(row("info_id")), row("info_id"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = row("info_id2")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = If(Not IsDBNull(row("firstname2")), row("firstname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = If(Not IsDBNull(row("middlename2")), row("middlename2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = If(Not IsDBNull(row("lastname2")), row("lastname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = If(Not IsDBNull(row("sex1")), row("sex1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(row("birthdate1")), row("birthdate1"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(row("phonenumber1")), row("phonenumber1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = If(Not IsDBNull(row("nationality")), row("nationality"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = If(Not IsDBNull(row("email")), row("email"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), Nothing)
                    consultation.Diagnostics = New Diagnostics
                    Dim diagnosticController As New DiagnosticsController
                    consultation.Diagnostics = diagnosticController.GetPatientCertainDiagnostics_Consultation(consultation.Consultation_ID)
                    consultation.Prescriptions = New List(Of Prescription)
                    Dim prescriptionController As New PrescriptionController
                    consultation.Prescriptions = prescriptionController.GetPatientPrescribeMeds_Consulation(consultation.Consultation_ID)
                    consultations.Add(consultation)
                    consultation.FollowUpConsultation = New List(Of FollowUpConsultation)
                    Dim followupController As New FollowUpConsultationController
                    consultation.FollowUpConsultation = followupController.GetCertainConsultations_FollowUpConsultations(consultation.Consultation_ID)
                    consultation.ERTraigeForm = Me.GetPatientERCharts(consultation)
                    consultation.ERDoctorsOrder = Me.GetPatientDoctorOrder(consultation)
                    consultation.ProgressNotes = Me.GetProgressNotes(consultation.Consultation_ID)
                Next
                Return consultations
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetLatestCustomerConsultation(infoID As Long, fkEmdPatient As Long) As CustomerConsultation
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or f.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * 
                               FROM [dbo].[customervitals] as a
                               JOIN [wmmcqms].[servedcustomer] as b on a.served_id = b.served_id
                               JOIN [wmmcqms].[customerassigncounter] as c on b.customerassigncounter_id = c.customerassigncounter_id
                               JOIN [wmmcqms].[customer] as d on c.customer_id = d.customer_id
                               JOIN [wmmcqms].[servertransaction] as e on b.servertransaction_id = e.servertransaction_id
                               JOIN [wmmcqms].[serverassigncounter] as f on e.serverassigncounter_id = f.serverassigncounter_ID
                               JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                               JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                               JOIN [dbo].[customerinfo] as i on d.info_id = i.info_id
                               WHERE (dataType = 0 OR dataType = 0) AND [consultation_id] = (SELECT MAX([consultation_id]) from [customervitals] as f WHERE f.info_id = @ID " & qry & ")"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = data.Rows(0)("consultation_id")
                    consultation.Weight = data.Rows(0)("weight")
                    consultation.WeightUnit = data.Rows(0)("weightunit").ToString.Trim
                    consultation.Height = data.Rows(0)("height")
                    consultation.HeightUnit = data.Rows(0)("heightunit").ToString.Trim
                    consultation.Systolic = data.Rows(0)("systolic")
                    consultation.Diastolic = data.Rows(0)("diastolic")
                    consultation.Temperature = data.Rows(0)("temperature")
                    consultation.PulseRate = data.Rows(0)("pulserate")
                    consultation.RespiratoryRate = data.Rows(0)("respiratoryrate")
                    consultation.Oxygen = data.Rows(0)("oxygen")
                    consultation.ChiefComplaint = data.Rows(0)("chiefcomplaint")
                    consultation.IllnessHistory = data.Rows(0)("illnesshistory")
                    consultation.Diagnosis = data.Rows(0)("diagnosis")
                    consultation.DoctorsOrder = data.Rows(0)("doctorsorder")
                    consultation.DateCreated = If(Not IsDBNull(data.Rows(0)("datecreated")), data.Rows(0)("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(data.Rows(0)("datemodified")), data.Rows(0)("datemodified"), Nothing)
                    consultation.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    consultation.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    consultation.ServerTransaction.CounterName = data.Rows(0)("countername")
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = data.Rows(0)("consultationView")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname1")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = data.Rows(0)("prc")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = data.Rows(0)("ptr")
                    consultation.ServedCustomer = New ServedCustomer()
                    consultation.ServedCustomer.ServedCustomer_ID = data.Rows(0)("server_id")
                    consultation.ServedCustomer.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServedCustomer.CustomerAssginCounter_ID = data.Rows(0)("customerassigncounter_id")
                    consultation.ServedCustomer.DateTimeStart = If(Not IsDBNull(data.Rows(0)("datetimeservedstart")), data.Rows(0)("datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not IsDBNull(data.Rows(0)("datetimeservedend")), data.Rows(0)("datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = data.Rows(0)("customerassigncounter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = data.Rows(0)("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = data.Rows(0)("datetimequeued")
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = data.Rows(0)("priority")
                    consultation.ServedCustomer.CustomerAssignCounter.Result = data.Rows(0)("result")
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = data.Rows(0)("queuenumber")
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = data.Rows(0)("paymentmethod")
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = If(Not IsDBNull(data.Rows(0)("notes")), data.Rows(0)("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(data.Rows(0)("notedepartment")), data.Rows(0)("notedepartment"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(data.Rows(0)("notesection")), data.Rows(0)("notesection"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = If(Not IsDBNull(data.Rows(0)("notes")), data.Rows(0)("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = data.Rows(0)("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = If(Not IsDBNull(data.Rows(0)("fullname")), data.Rows(0)("fullname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = If(Not IsDBNull(data.Rows(0)("firstname")), data.Rows(0)("firstname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = If(Not IsDBNull(data.Rows(0)("middlename")), data.Rows(0)("middlename"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = If(Not IsDBNull(data.Rows(0)("lastname")), data.Rows(0)("lastname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = If(Not IsDBNull(data.Rows(0)("sex")), data.Rows(0)("sex"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = If(Not IsDBNull(data.Rows(0)("birthdate")), data.Rows(0)("birthdate"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = If(Not IsDBNull(data.Rows(0)("civilstatus")), data.Rows(0)("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = If(Not IsDBNull(data.Rows(0)("address")), data.Rows(0)("address"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = If(Not IsDBNull(data.Rows(0)("phonenumber")), data.Rows(0)("phonenumber"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = data.Rows(0)("dateofvisit")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = If(Not IsDBNull(data.Rows(0)("FK_emdPatients")), data.Rows(0)("FK_emdPatients"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = If(Not IsDBNull(data.Rows(0)("info_id")), data.Rows(0)("info_id"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = data.Rows(0)("info_id2")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = If(Not IsDBNull(data.Rows(0)("firstname2")), data.Rows(0)("firstname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = If(Not IsDBNull(data.Rows(0)("middlename2")), data.Rows(0)("middlename2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = If(Not IsDBNull(data.Rows(0)("lastname2")), data.Rows(0)("lastname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = If(Not IsDBNull(data.Rows(0)("sex1")), data.Rows(0)("sex1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(data.Rows(0)("birthdate1")), data.Rows(0)("birthdate1"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(data.Rows(0)("civilstatus")), data.Rows(0)("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(data.Rows(0)("street")), data.Rows(0)("street"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = If(Not IsDBNull(data.Rows(0)("barangay")), data.Rows(0)("barangay"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(data.Rows(0)("city")), data.Rows(0)("city"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(data.Rows(0)("phonenumber1")), data.Rows(0)("phonenumber1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = If(Not IsDBNull(data.Rows(0)("nationality")), data.Rows(0)("nationality"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = If(Not IsDBNull(data.Rows(0)("email")), data.Rows(0)("email"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(data.Rows(0)("FK_emdPatients")), data.Rows(0)("FK_emdPatients"), Nothing)
                    consultation.Prescriptions = New List(Of Prescription)
                    Dim prescriptionController As New PrescriptionController
                    consultation.Prescriptions = prescriptionController.GetPatientPrescribeMeds_Consulation(consultation.Consultation_ID)
                    consultation.Diagnostics = New Diagnostics
                    Dim diagnosticController As New DiagnosticsController
                    consultation.Diagnostics = diagnosticController.GetPatientCertainDiagnostics_Consultation(consultation.Consultation_ID)
                    Return consultation
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetLatestAPatientConsultation_GenerateConsultation(patient As ServedCustomer) As CustomerConsultation
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [customervitals] as a JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id WHERE (dataType = 0 OR dataType = 0) AND [consultation_id] = (SELECT MAX([consultation_id]) from [customervitals] as f WHERE  [served_id] = @ID)"
            cmd.Parameters.AddWithValue("@ID", patient.ServedCustomer_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdCreateNewConsulation As New SqlCommand
                    cmdCreateNewConsulation.CommandText = "INSERT INTO [dbo].[customervitals] 
                                                           ([weight] ,[weightunit] ,[height] ,[heightunit] , [pain], [painlocation], [allergies], [signsymptoms], [systolic] ,[diastolic] ,[temperature] ,[pulserate] ,[respiratoryrate] ,[oxygen] , [hypertension], [diabetes], [asthma], [tuberculosis], [cancer], [stroke], [arthritis], [hearthdisease], [othermedicalhistory], [medicinetaken], [chiefcomplaint] ,[illnesshistory] ,[diagnosis] ,[doctorsorder] ,[FK_emdPatients] ,[servertransaction_id] ,[info_id], [served_id] ,[findings] ,[copd]) VALUES
                                                           (@wgt ,@wgtunit ,@hgt ,@hgtunit ,@pain ,@painloc ,@allergy ,@signSymp ,@sys ,@dia ,@tmp ,@pr ,@rr ,@o2, @hptension, @diabts, @astma, @tb, @cncr, @strk, @arths, @hrds,@opmed,@medtk,@chiefcom ,@ihist ,@dgnosis ,@dorder ,@fkid ,@stid ,@inid, @ID, @fnds, @copd);SELECT @@IDENTITY;"
                    cmdCreateNewConsulation.Parameters.AddWithValue("@wgt", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@wgtunit", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@hgt", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@hgtunit", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@pain", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@painloc", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@allergy", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@signSymp", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@sys", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@dia", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@tmp", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@pr", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@rr", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@o2", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@hptension", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@diabts", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@astma", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@tb", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@cncr", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@strk", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@arths", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@hrds", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@copd", 0)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@opmed", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@medtk", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@chiefcom", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@ihist", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@dgnosis", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@dorder", "")
                    cmdCreateNewConsulation.Parameters.AddWithValue("@fkid", patient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@stid", If(patient.ServerTransaction_ID > 0, patient.ServerTransaction_ID, patient.ServerTransaction.ServerTransaction_ID))
                    cmdCreateNewConsulation.Parameters.AddWithValue("@inid", patient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@ID", patient.ServedCustomer_ID)
                    cmdCreateNewConsulation.Parameters.AddWithValue("@fnds", "")
                    Dim consultationID As Long = excecuteCommandReturnID(cmdCreateNewConsulation)
                    If consultationID > 0 Then
                        cmd = New SqlCommand
                        cmd.CommandText = "SELECT * FROM [customervitals] as a  JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id WHERE (dataType = 0 OR dataType = 0) AND [consultation_id] = (SELECT MAX([consultation_id]) from [customervitals] as f WHERE  f.pccConsultation = 0 AND [consultation_id] = @ID)"
                        cmd.Parameters.AddWithValue("@ID", consultationID)
                        data = fetchData(cmd).Tables(0)
                        If IsNothing(data) Then
                            Return Nothing
                        ElseIf Not data.Rows.Count > 0 Then
                            Return Nothing
                        End If
                    End If
                End If
                Dim consultation As New CustomerConsultation
                consultation.Consultation_ID = data.Rows(0)("consultation_id")
                consultation.Weight = If(Not IsDBNull(data.Rows(0)("weight")), data.Rows(0)("weight"), 0)
                consultation.WeightUnit = If(Not IsDBNull(data.Rows(0)("weightunit")), data.Rows(0)("weightunit").ToString.Trim, "")
                consultation.Height = If(Not IsDBNull(data.Rows(0)("height")), data.Rows(0)("height"), 0)
                consultation.HeightUnit = If(Not IsDBNull(data.Rows(0)("heightunit")), data.Rows(0)("heightunit").ToString.Trim, "")
                consultation.Pain = If(Not IsDBNull(data.Rows(0)("pain")), data.Rows(0)("pain").ToString.Trim, "")
                consultation.PainLocation = If(Not IsDBNull(data.Rows(0)("painlocation")), data.Rows(0)("painlocation").ToString.Trim, "")
                consultation.Allergies = If(Not IsDBNull(data.Rows(0)("allergies")), data.Rows(0)("allergies").ToString.Trim, "")
                consultation.SignAndSymptoms = If(Not IsDBNull(data.Rows(0)("signsymptoms")), data.Rows(0)("signsymptoms").ToString.Trim, "")
                consultation.Systolic = If(Not IsDBNull(data.Rows(0)("systolic")), data.Rows(0)("systolic"), 0)
                consultation.Diastolic = If(Not IsDBNull(data.Rows(0)("diastolic")), data.Rows(0)("diastolic"), 0)
                consultation.Temperature = If(Not IsDBNull(data.Rows(0)("temperature")), data.Rows(0)("temperature"), 0)
                consultation.PulseRate = If(Not IsDBNull(data.Rows(0)("pulserate")), data.Rows(0)("pulserate"), 0)
                consultation.RespiratoryRate = If(Not IsDBNull(data.Rows(0)("respiratoryrate")), data.Rows(0)("respiratoryrate"), 0)
                consultation.Oxygen = If(Not IsDBNull(data.Rows(0)("oxygen")), data.Rows(0)("oxygen"), 0)
                consultation.Hypertension = If(Not IsDBNull(data.Rows(0)("hypertension")), data.Rows(0)("hypertension"), 0)
                consultation.Diabetes = If(Not IsDBNull(data.Rows(0)("diabetes")), data.Rows(0)("diabetes"), 0)
                consultation.Asthma = If(Not IsDBNull(data.Rows(0)("asthma")), data.Rows(0)("asthma"), 0)
                consultation.Tuberculosis = If(Not IsDBNull(data.Rows(0)("tuberculosis")), data.Rows(0)("tuberculosis"), 0)
                consultation.Cancer = If(Not IsDBNull(data.Rows(0)("cancer")), data.Rows(0)("cancer"), 0)
                consultation.Stroke = If(Not IsDBNull(data.Rows(0)("stroke")), data.Rows(0)("stroke"), 0)
                consultation.Arthitis = If(Not IsDBNull(data.Rows(0)("arthritis")), data.Rows(0)("arthritis"), 0)
                consultation.HeartDisease = If(Not IsDBNull(data.Rows(0)("hearthdisease")), data.Rows(0)("hearthdisease"), 0)
                consultation.COPD = If(Not IsDBNull(data.Rows(0)("copd")), data.Rows(0)("copd"), 0)
                consultation.TransferredReferred = If(Not IsDBNull(data.Rows(0)("transferredreferred")), data.Rows(0)("transferredreferred"), 0)
                consultation.RefusedAdmission = If(Not IsDBNull(data.Rows(0)("refusedadmission")), data.Rows(0)("refusedadmission"), 0)
                consultation.ERDeath = If(Not IsDBNull(data.Rows(0)("erdeath")), data.Rows(0)("erdeath"), 0)
                consultation.Discharged = If(Not IsDBNull(data.Rows(0)("discharged")), data.Rows(0)("discharged"), 0)
                consultation.ForFollowUp = If(Not IsDBNull(data.Rows(0)("forfollowup")), data.Rows(0)("forfollowup"), 0)
                consultation.Absconed = If(Not IsDBNull(data.Rows(0)("absconed")), data.Rows(0)("absconed"), 0)
                consultation.HAMADAMA = If(Not IsDBNull(data.Rows(0)("hamadam")), data.Rows(0)("hamadam"), 0)
                consultation.DOA = If(Not IsDBNull(data.Rows(0)("doa")), data.Rows(0)("doa"), 0)
                consultation.Admitted = If(Not IsDBNull(data.Rows(0)("admitted")), data.Rows(0)("admitted"), 0)
                consultation.RoomAdmitted = If(Not IsDBNull(data.Rows(0)("admittedroom")), data.Rows(0)("admittedroom"), "")
                consultation.WardAdmitted = If(Not IsDBNull(data.Rows(0)("admittedward")), data.Rows(0)("admittedward"), "")
                consultation.AdmittedProgressNote = If(Not IsDBNull(data.Rows(0)("admissionprogressnote")), data.Rows(0)("admissionprogressnote"), "")
                consultation.AdmittedDoctorsOrder = If(Not IsDBNull(data.Rows(0)("admissiondoctororder")), data.Rows(0)("admissiondoctororder"), "")
                consultation.AdmittedRemarks = If(Not IsDBNull(data.Rows(0)("admissionremarks")), data.Rows(0)("admissionremarks"), "")
                consultation.othermedicalhistory = If(Not IsDBNull(data.Rows(0)("othermedicalhistory")), data.Rows(0)("othermedicalhistory").ToString.Trim, "")
                consultation.MedicineTaken = If(Not IsDBNull(data.Rows(0)("medicinetaken")), data.Rows(0)("medicinetaken").ToString.Trim, "")
                consultation.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("chiefcomplaint")), data.Rows(0)("chiefcomplaint").ToString.Trim, "")
                consultation.IllnessHistory = If(Not IsDBNull(data.Rows(0)("illnesshistory")), data.Rows(0)("illnesshistory").ToString.Trim, "")
                consultation.Findings = If(Not IsDBNull(data.Rows(0)("findings")), data.Rows(0)("findings").ToString.Trim, "")
                consultation.Diagnosis = If(Not IsDBNull(data.Rows(0)("diagnosis")), data.Rows(0)("diagnosis").ToString.Trim, "")
                consultation.DoctorsOrder = If(Not IsDBNull(data.Rows(0)("doctorsorder")), data.Rows(0)("doctorsorder").ToString.Trim, "")
                consultation.isEConsulta = data.Rows(0)("isEConsulta")
                consultation.isFollowUpConsultation = data.Rows(0)("isFollowUpConsultation")
                consultation.DateCreated = If(Not IsDBNull(data.Rows(0)("datecreated")), data.Rows(0)("datecreated"), Nothing)
                consultation.DateModified = If(Not IsDBNull(data.Rows(0)("datemodified")), data.Rows(0)("datemodified"), Nothing)
                consultation.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                consultation.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                consultation.ServerTransaction = New ServerTransaction
                consultation.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                consultation.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                consultation.ServerTransaction.CounterName = data.Rows(0)("countername")
                consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                consultation.ServerTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                consultation.ServerTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                consultation.ServerTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                consultation.ServerTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = data.Rows(0)("consultationView")
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                consultation.ServerTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname")
                consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                Return consultation
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetLatestAPatientConsultation_GetAndUpdateInitialConsultation_GeneratePCCConsultation(patient As ServedCustomer) As CustomerConsultation
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [customervitals] as a JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id WHERE (dataType = 0 OR dataType = 0) AND [consultation_id] = (SELECT MAX([consultation_id]) from [customervitals] as f WHERE  [served_id] = @ID)"
            cmd.Parameters.AddWithValue("@ID", patient.ServedCustomer_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdGetInitialConsultation As New SqlCommand
                    cmdGetInitialConsultation.CommandText = "SELECT * FROM [customervitals] WHERE [consultation_id] = (SELECT MAX([consultation_id]) from [customervitals] as f WHERE f.tempqueue = 1 AND f.pccConsultation = 1 AND CONVERT(DATE, f.datecreated) = CONVERT(DATE, GETDATE()) AND [info_id] = @ID)"
                    cmdGetInitialConsultation.Parameters.AddWithValue("@ID", patient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                    data = fetchData(cmdGetInitialConsultation).Tables(0)
                    If Not IsNothing(data) Then
                        Dim consultationID As Long = 0
                        If data.Rows.Count > 0 Then
                            Dim consID As Long = data.Rows(0)("consultation_id")
                            Dim cmdMakeInitialMine As New SqlCommand
                            cmdMakeInitialMine.CommandText = "UPDATE [dbo].[customervitals]  SET  [tempqueue] = 0 ,[datemodified] = GETDATE() ,[servertransaction_id] = @stid ,[served_id] = @sid WHERE [consultation_id] = @ID"
                            cmdMakeInitialMine.Parameters.AddWithValue("@stid", If(patient.ServerTransaction_ID > 0, patient.ServerTransaction_ID, patient.ServerTransaction.ServerTransaction_ID))
                            cmdMakeInitialMine.Parameters.AddWithValue("@sid", patient.ServedCustomer_ID)
                            cmdMakeInitialMine.Parameters.AddWithValue("@ID", consID)
                            If excecuteCommand(cmdMakeInitialMine) Then
                                consultationID = consID
                            End If
                        Else
                            Dim cmdCreateNewConsulation As New SqlCommand
                            cmdCreateNewConsulation.CommandText = "INSERT INTO [dbo].[customervitals] 
                                                                   ([weight] ,[weightunit] ,[height] ,[heightunit] , [pain], [painlocation], [allergies], [signsymptoms], [systolic] ,[diastolic] ,[temperature] ,[pulserate] ,[respiratoryrate] ,[oxygen] , [hypertension], [diabetes], [asthma], [tuberculosis], [cancer], [stroke], [arthritis], [hearthdisease], [othermedicalhistory], [medicinetaken], [chiefcomplaint] ,[illnesshistory] ,[diagnosis] ,[doctorsorder] ,[FK_emdPatients] ,[servertransaction_id] ,[info_id], [served_id], [pccConsultation], [findings], [copd]) VALUES
                                                                   (@wgt ,@wgtunit ,@hgt ,@hgtunit ,@pain ,@painloc ,@allergy ,@signSymp ,@sys ,@dia ,@tmp ,@pr ,@rr ,@o2, @hptension, @diabts, @astma, @tb, @cncr, @strk, @arths, @hrds,@opmed,@medtk,@chiefcom ,@ihist ,@dgnosis ,@dorder ,@fkid ,@stid ,@inid, @ID, 1, @fnds, @copd); SELECT @@IDENTITY;"
                            cmdCreateNewConsulation.Parameters.AddWithValue("@wgt", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@wgtunit", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@hgt", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@hgtunit", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@pain", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@painloc", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@allergy", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@signSymp", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@sys", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@dia", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@tmp", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@pr", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@rr", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@o2", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@hptension", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@diabts", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@astma", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@tb", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@cncr", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@strk", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@arths", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@hrds", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@copd", 0)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@opmed", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@medtk", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@chiefcom", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@ihist", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@dgnosis", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@dorder", "")
                            cmdCreateNewConsulation.Parameters.AddWithValue("@fkid", patient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@stid", If(patient.ServerTransaction_ID > 0, patient.ServerTransaction_ID, patient.ServerTransaction.ServerTransaction_ID))
                            cmdCreateNewConsulation.Parameters.AddWithValue("@inid", patient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@ID", patient.ServedCustomer_ID)
                            cmdCreateNewConsulation.Parameters.AddWithValue("@fnds", "")
                            consultationID = excecuteCommandReturnID(cmdCreateNewConsulation)
                        End If
                        If consultationID > 0 Then
                            cmd = New SqlCommand
                            cmd.CommandText = "SELECT * FROM [customervitals] as a  JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id WHERE (dataType = 0 OR dataType = 0) AND [consultation_id] = (SELECT MAX([consultation_id]) from [customervitals] as f WHERE [consultation_id] = @ID)"
                            cmd.Parameters.AddWithValue("@ID", consultationID)
                            data = fetchData(cmd).Tables(0)
                            If IsNothing(data) Then
                                Return Nothing
                            ElseIf Not data.Rows.Count > 0 Then
                                Return Nothing
                            End If
                        End If
                    End If
                End If
                Dim consultation As New CustomerConsultation
                consultation.Consultation_ID = data.Rows(0)("consultation_id")
                consultation.Weight = If(Not IsDBNull(data.Rows(0)("weight")), data.Rows(0)("weight"), 0)
                consultation.WeightUnit = If(Not IsDBNull(data.Rows(0)("weightunit")), data.Rows(0)("weightunit").ToString.Trim, "")
                consultation.Height = If(Not IsDBNull(data.Rows(0)("height")), data.Rows(0)("height"), 0)
                consultation.HeightUnit = If(Not IsDBNull(data.Rows(0)("heightunit")), data.Rows(0)("heightunit").ToString.Trim, "")
                consultation.Pain = If(Not IsDBNull(data.Rows(0)("pain")), data.Rows(0)("pain").ToString.Trim, "")
                consultation.PainLocation = If(Not IsDBNull(data.Rows(0)("painlocation")), data.Rows(0)("painlocation").ToString.Trim, "")
                consultation.Allergies = If(Not IsDBNull(data.Rows(0)("allergies")), data.Rows(0)("allergies").ToString.Trim, "")
                consultation.SignAndSymptoms = If(Not IsDBNull(data.Rows(0)("signsymptoms")), data.Rows(0)("signsymptoms").ToString.Trim, "")
                consultation.Systolic = If(Not IsDBNull(data.Rows(0)("systolic")), data.Rows(0)("systolic"), 0)
                consultation.Diastolic = If(Not IsDBNull(data.Rows(0)("diastolic")), data.Rows(0)("diastolic"), 0)
                consultation.Temperature = If(Not IsDBNull(data.Rows(0)("temperature")), data.Rows(0)("temperature"), 0)
                consultation.PulseRate = If(Not IsDBNull(data.Rows(0)("pulserate")), data.Rows(0)("pulserate"), 0)
                consultation.RespiratoryRate = If(Not IsDBNull(data.Rows(0)("respiratoryrate")), data.Rows(0)("respiratoryrate"), 0)
                consultation.Oxygen = If(Not IsDBNull(data.Rows(0)("oxygen")), data.Rows(0)("oxygen"), 0)
                consultation.Hypertension = If(Not IsDBNull(data.Rows(0)("hypertension")), data.Rows(0)("hypertension"), 0)
                consultation.Diabetes = If(Not IsDBNull(data.Rows(0)("diabetes")), data.Rows(0)("diabetes"), 0)
                consultation.Asthma = If(Not IsDBNull(data.Rows(0)("asthma")), data.Rows(0)("asthma"), 0)
                consultation.Tuberculosis = If(Not IsDBNull(data.Rows(0)("tuberculosis")), data.Rows(0)("tuberculosis"), 0)
                consultation.Cancer = If(Not IsDBNull(data.Rows(0)("cancer")), data.Rows(0)("cancer"), 0)
                consultation.Stroke = If(Not IsDBNull(data.Rows(0)("stroke")), data.Rows(0)("stroke"), 0)
                consultation.Arthitis = If(Not IsDBNull(data.Rows(0)("arthritis")), data.Rows(0)("arthritis"), 0)
                consultation.HeartDisease = If(Not IsDBNull(data.Rows(0)("hearthdisease")), data.Rows(0)("hearthdisease"), 0)
                consultation.COPD = If(Not IsDBNull(data.Rows(0)("copd")), data.Rows(0)("copd"), 0)
                consultation.TransferredReferred = If(Not IsDBNull(data.Rows(0)("transferredreferred")), data.Rows(0)("transferredreferred"), 0)
                consultation.RefusedAdmission = If(Not IsDBNull(data.Rows(0)("refusedadmission")), data.Rows(0)("refusedadmission"), 0)
                consultation.ERDeath = If(Not IsDBNull(data.Rows(0)("erdeath")), data.Rows(0)("erdeath"), 0)
                consultation.Discharged = If(Not IsDBNull(data.Rows(0)("discharged")), data.Rows(0)("discharged"), 0)
                consultation.ForFollowUp = If(Not IsDBNull(data.Rows(0)("forfollowup")), data.Rows(0)("forfollowup"), 0)
                consultation.Absconed = If(Not IsDBNull(data.Rows(0)("absconed")), data.Rows(0)("absconed"), 0)
                consultation.HAMADAMA = If(Not IsDBNull(data.Rows(0)("hamadam")), data.Rows(0)("hamadam"), 0)
                consultation.DOA = If(Not IsDBNull(data.Rows(0)("doa")), data.Rows(0)("doa"), 0)
                consultation.Admitted = If(Not IsDBNull(data.Rows(0)("admitted")), data.Rows(0)("admitted"), 0)
                consultation.RoomAdmitted = If(Not IsDBNull(data.Rows(0)("admittedroom")), data.Rows(0)("admittedroom"), "")
                consultation.WardAdmitted = If(Not IsDBNull(data.Rows(0)("admittedward")), data.Rows(0)("admittedward"), "")
                consultation.AdmittedProgressNote = If(Not IsDBNull(data.Rows(0)("admissionprogressnote")), data.Rows(0)("admissionprogressnote"), "")
                consultation.AdmittedDoctorsOrder = If(Not IsDBNull(data.Rows(0)("admissiondoctororder")), data.Rows(0)("admissiondoctororder"), "")
                consultation.AdmittedRemarks = If(Not IsDBNull(data.Rows(0)("admissionremarks")), data.Rows(0)("admissionremarks"), "")
                consultation.othermedicalhistory = If(Not IsDBNull(data.Rows(0)("othermedicalhistory")), data.Rows(0)("othermedicalhistory").ToString.Trim, "")
                consultation.MedicineTaken = If(Not IsDBNull(data.Rows(0)("medicinetaken")), data.Rows(0)("medicinetaken").ToString.Trim, "")
                consultation.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("chiefcomplaint")), data.Rows(0)("chiefcomplaint").ToString.Trim, "")
                consultation.IllnessHistory = If(Not IsDBNull(data.Rows(0)("illnesshistory")), data.Rows(0)("illnesshistory").ToString.Trim, "")
                consultation.Findings = If(Not IsDBNull(data.Rows(0)("findings")), data.Rows(0)("findings").ToString.Trim, "")
                consultation.Diagnosis = If(Not IsDBNull(data.Rows(0)("diagnosis")), data.Rows(0)("diagnosis").ToString.Trim, "")
                consultation.DoctorsOrder = If(Not IsDBNull(data.Rows(0)("doctorsorder")), data.Rows(0)("doctorsorder").ToString.Trim, "")
                consultation.OPDConsent1 = If(Not IsDBNull(data.Rows(0)("opdconsent")), data.Rows(0)("opdconsent").ToString.Trim, "")
                consultation.OPDConsent2 = If(Not IsDBNull(data.Rows(0)("opdconsent2")), data.Rows(0)("opdconsent2").ToString.Trim, "")
                consultation.TriageNurseOnDuty = If(Not IsDBNull(data.Rows(0)("traigenurseonduty")), data.Rows(0)("traigenurseonduty").ToString.Trim, "")
                consultation.isFollowUpConsultation = data.Rows(0)("isFollowUpConsultation")
                consultation.isEConsulta = data.Rows(0)("isEConsulta")
                consultation.isHealee = data.Rows(0)("isHelee")
                consultation.DateCreated = If(Not IsDBNull(data.Rows(0)("datecreated")), data.Rows(0)("datecreated"), Nothing)
                consultation.DateModified = If(Not IsDBNull(data.Rows(0)("datemodified")), data.Rows(0)("datemodified"), Nothing)
                consultation.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                consultation.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                consultation.ServerTransaction = New ServerTransaction
                consultation.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                consultation.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                consultation.ServerTransaction.CounterName = data.Rows(0)("countername")
                consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                consultation.ServerTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                consultation.ServerTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                consultation.ServerTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                consultation.ServerTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = data.Rows(0)("consultationView")
                consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                consultation.ServerTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname")
                consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                Return consultation
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function



    Public Function GetCertainPatientConsultation(ID As Long) As CustomerConsultation
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * 
                               FROM [dbo].[customervitals] as a
                               JOIN [wmmcqms].[servedcustomer] as b on a.served_id = b.served_id
                               JOIN [wmmcqms].[customerassigncounter] as c on b.customerassigncounter_id = c.customerassigncounter_id
                               JOIN [wmmcqms].[customer] as d on c.customer_id = d.customer_id
                               JOIN [wmmcqms].[servertransaction] as e on b.servertransaction_id = e.servertransaction_id
                               JOIN [wmmcqms].[serverassigncounter] as f on e.serverassigncounter_id = f.serverassigncounter_ID
                               JOIN [wmmcqms].[server] as g on g.server_id = f.server_id
                               JOIN [wmmcqms].[counter] as h on h.counter_id = f.counter_id
                               LEFT JOIN [dbo].[customerinfo] as i on d.info_id = i.info_id 
                               WHERE [consultation_id] = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim consultation As New CustomerConsultation
                    consultation.Consultation_ID = data.Rows(0)("consultation_id")
                    consultation.Weight = If(Not IsDBNull(data.Rows(0)("weight")), data.Rows(0)("weight"), 0)
                    consultation.WeightUnit = If(Not IsDBNull(data.Rows(0)("weightunit")), data.Rows(0)("weightunit").ToString.Trim, "")
                    consultation.Height = If(Not IsDBNull(data.Rows(0)("height")), data.Rows(0)("height"), 0)
                    consultation.HeightUnit = If(Not IsDBNull(data.Rows(0)("heightunit")), data.Rows(0)("heightunit").ToString.Trim, "")
                    consultation.Pain = If(Not IsDBNull(data.Rows(0)("pain")), data.Rows(0)("pain").ToString.Trim, "")
                    consultation.PainLocation = If(Not IsDBNull(data.Rows(0)("painlocation")), data.Rows(0)("painlocation").ToString.Trim, "")
                    consultation.Allergies = If(Not IsDBNull(data.Rows(0)("allergies")), data.Rows(0)("allergies").ToString.Trim, "")
                    consultation.SignAndSymptoms = If(Not IsDBNull(data.Rows(0)("signsymptoms")), data.Rows(0)("signsymptoms").ToString.Trim, "")
                    consultation.Systolic = If(Not IsDBNull(data.Rows(0)("systolic")), data.Rows(0)("systolic"), 0)
                    consultation.Diastolic = If(Not IsDBNull(data.Rows(0)("diastolic")), data.Rows(0)("diastolic"), 0)
                    consultation.Temperature = If(Not IsDBNull(data.Rows(0)("temperature")), data.Rows(0)("temperature"), 0)
                    consultation.PulseRate = If(Not IsDBNull(data.Rows(0)("pulserate")), data.Rows(0)("pulserate"), 0)
                    consultation.RespiratoryRate = If(Not IsDBNull(data.Rows(0)("respiratoryrate")), data.Rows(0)("respiratoryrate"), 0)
                    consultation.Oxygen = If(Not IsDBNull(data.Rows(0)("oxygen")), data.Rows(0)("oxygen"), 0)
                    consultation.Hypertension = If(Not IsDBNull(data.Rows(0)("hypertension")), data.Rows(0)("hypertension"), 0)
                    consultation.Diabetes = If(Not IsDBNull(data.Rows(0)("diabetes")), data.Rows(0)("diabetes"), 0)
                    consultation.Asthma = If(Not IsDBNull(data.Rows(0)("asthma")), data.Rows(0)("asthma"), 0)
                    consultation.Tuberculosis = If(Not IsDBNull(data.Rows(0)("tuberculosis")), data.Rows(0)("tuberculosis"), 0)
                    consultation.Cancer = If(Not IsDBNull(data.Rows(0)("cancer")), data.Rows(0)("cancer"), 0)
                    consultation.Stroke = If(Not IsDBNull(data.Rows(0)("stroke")), data.Rows(0)("stroke"), 0)
                    consultation.Arthitis = If(Not IsDBNull(data.Rows(0)("arthritis")), data.Rows(0)("arthritis"), 0)
                    consultation.HeartDisease = If(Not IsDBNull(data.Rows(0)("hearthdisease")), data.Rows(0)("hearthdisease"), 0)
                    consultation.COPD = If(Not IsDBNull(data.Rows(0)("copd")), data.Rows(0)("copd"), 0)
                    consultation.TransferredReferred = If(Not IsDBNull(data.Rows(0)("transferredreferred")), data.Rows(0)("transferredreferred"), 0)
                    consultation.RefusedAdmission = If(Not IsDBNull(data.Rows(0)("refusedadmission")), data.Rows(0)("refusedadmission"), 0)
                    consultation.ERDeath = If(Not IsDBNull(data.Rows(0)("erdeath")), data.Rows(0)("erdeath"), 0)
                    consultation.Discharged = If(Not IsDBNull(data.Rows(0)("discharged")), data.Rows(0)("discharged"), 0)
                    consultation.ForFollowUp = If(Not IsDBNull(data.Rows(0)("forfollowup")), data.Rows(0)("forfollowup"), 0)
                    consultation.Absconed = If(Not IsDBNull(data.Rows(0)("absconed")), data.Rows(0)("absconed"), 0)
                    consultation.HAMADAMA = If(Not IsDBNull(data.Rows(0)("hamadam")), data.Rows(0)("hamadam"), 0)
                    consultation.DOA = If(Not IsDBNull(data.Rows(0)("doa")), data.Rows(0)("doa"), 0)
                    consultation.Admitted = If(Not IsDBNull(data.Rows(0)("admitted")), data.Rows(0)("admitted"), 0)
                    consultation.RoomAdmitted = If(Not IsDBNull(data.Rows(0)("admittedroom")), data.Rows(0)("admittedroom"), "")
                    consultation.WardAdmitted = If(Not IsDBNull(data.Rows(0)("admittedward")), data.Rows(0)("admittedward"), "")
                    consultation.AdmittedProgressNote = If(Not IsDBNull(data.Rows(0)("admissionprogressnote")), data.Rows(0)("admissionprogressnote"), "")
                    consultation.AdmittedDoctorsOrder = If(Not IsDBNull(data.Rows(0)("admissiondoctororder")), data.Rows(0)("admissiondoctororder"), "")
                    consultation.AdmittedRemarks = If(Not IsDBNull(data.Rows(0)("admissionremarks")), data.Rows(0)("admissionremarks"), "")
                    consultation.othermedicalhistory = If(Not IsDBNull(data.Rows(0)("othermedicalhistory")), data.Rows(0)("othermedicalhistory").ToString.Trim, "")
                    consultation.MedicineTaken = If(Not IsDBNull(data.Rows(0)("medicinetaken")), data.Rows(0)("medicinetaken").ToString.Trim, "")
                    consultation.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("chiefcomplaint")), data.Rows(0)("chiefcomplaint").ToString.Trim, "")
                    consultation.IllnessHistory = If(Not IsDBNull(data.Rows(0)("illnesshistory")), data.Rows(0)("illnesshistory").ToString.Trim, "")
                    consultation.Findings = If(Not IsDBNull(data.Rows(0)("findings")), data.Rows(0)("findings").ToString.Trim, "")
                    consultation.Diagnosis = If(Not IsDBNull(data.Rows(0)("diagnosis")), data.Rows(0)("diagnosis").ToString.Trim, "")
                    consultation.DoctorsOrder = If(Not IsDBNull(data.Rows(0)("doctorsorder")), data.Rows(0)("doctorsorder").ToString.Trim, "")
                    consultation.OPDConsent1 = If(Not IsDBNull(data.Rows(0)("opdconsent")), data.Rows(0)("opdconsent").ToString.Trim, "")
                    consultation.OPDConsent2 = If(Not IsDBNull(data.Rows(0)("opdconsent2")), data.Rows(0)("opdconsent2").ToString.Trim, "")
                    consultation.TriageNurseOnDuty = If(Not IsDBNull(data.Rows(0)("traigenurseonduty")), data.Rows(0)("traigenurseonduty").ToString.Trim, "")
                    consultation.isFollowUpConsultation = data.Rows(0)("isFollowUpConsultation")
                    consultation.isEConsulta = data.Rows(0)("isEConsulta")
                    consultation.DateCreated = If(Not IsDBNull(data.Rows(0)("datecreated")), data.Rows(0)("datecreated"), Nothing)
                    consultation.DateModified = If(Not IsDBNull(data.Rows(0)("datemodified")), data.Rows(0)("datemodified"), Nothing)
                    consultation.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    consultation.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServerTransaction = New ServerTransaction
                    consultation.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    consultation.ServerTransaction.CounterName = data.Rows(0)("countername")
                    consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationView = data.Rows(0)("consultationView")
                    consultation.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                    consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                    consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                    consultation.ServerTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname1")
                    consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PRC = If(Not IsDBNull(data.Rows(0)("prc")), data.Rows(0)("prc"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.PTR = If(Not IsDBNull(data.Rows(0)("ptr")), data.Rows(0)("ptr"), "")
                    consultation.ServerTransaction.ServerAssignCounter.Server.S2No = If(Not IsDBNull(data.Rows(0)("s2")), data.Rows(0)("s2"), "")
                    consultation.ServedCustomer = New ServedCustomer()
                    consultation.ServedCustomer.ServedCustomer_ID = data.Rows(0)("server_id")
                    consultation.ServedCustomer.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    consultation.ServedCustomer.CustomerAssginCounter_ID = data.Rows(0)("customerassigncounter_id")
                    consultation.ServedCustomer.DateTimeStart = If(Not IsDBNull(data.Rows(0)("datetimeservedstart")), data.Rows(0)("datetimeservedstart"), Nothing)
                    consultation.ServedCustomer.DateTimeEnd = If(Not IsDBNull(data.Rows(0)("datetimeservedend")), data.Rows(0)("datetimeservedend"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter = New CustomerAssignCounter
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = data.Rows(0)("customerassigncounter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer_ID = data.Rows(0)("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.DateTimeQueued = data.Rows(0)("datetimequeued")
                    consultation.ServedCustomer.CustomerAssignCounter.Priority = data.Rows(0)("priority")
                    consultation.ServedCustomer.CustomerAssignCounter.Result = data.Rows(0)("result")
                    consultation.ServedCustomer.CustomerAssignCounter.QueueNumber = data.Rows(0)("queuenumber")
                    consultation.ServedCustomer.CustomerAssignCounter.PaymentMethod = data.Rows(0)("paymentmethod")
                    consultation.ServedCustomer.CustomerAssignCounter.Notes = If(Not IsDBNull(data.Rows(0)("notes")), data.Rows(0)("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(data.Rows(0)("notedepartment")), data.Rows(0)("notedepartment"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(data.Rows(0)("notesection")), data.Rows(0)("notesection"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = If(Not IsDBNull(data.Rows(0)("notes")), data.Rows(0)("notes"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer = New Customer
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Customer_ID = data.Rows(0)("customer_id")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FullName = If(Not IsDBNull(data.Rows(0)("fullname")), data.Rows(0)("fullname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FirstName = If(Not IsDBNull(data.Rows(0)("firstname")), data.Rows(0)("firstname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.MiddleName = If(Not IsDBNull(data.Rows(0)("middlename")), data.Rows(0)("middlename"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.LastName = If(Not IsDBNull(data.Rows(0)("lastname")), data.Rows(0)("lastname"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Sex = If(Not IsDBNull(data.Rows(0)("sex")), data.Rows(0)("sex"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Birthdate = If(Not IsDBNull(data.Rows(0)("birthdate")), data.Rows(0)("birthdate"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CivilStatus = If(Not IsDBNull(data.Rows(0)("civilstatus")), data.Rows(0)("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Address = If(Not IsDBNull(data.Rows(0)("address")), data.Rows(0)("address"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.PhoneNumber = If(Not IsDBNull(data.Rows(0)("phonenumber")), data.Rows(0)("phonenumber"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.DateOfVisit = data.Rows(0)("dateofvisit")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.FK_emdPatients = If(Not IsDBNull(data.Rows(0)("FK_emdPatients")), data.Rows(0)("FK_emdPatients"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.Info_ID = If(Not IsDBNull(data.Rows(0)("info_id")), data.Rows(0)("info_id"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo = New CustomerInfo
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID = data.Rows(0)("info_id2")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName = If(Not IsDBNull(data.Rows(0)("firstname2")), data.Rows(0)("firstname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename = If(Not IsDBNull(data.Rows(0)("middlename2")), data.Rows(0)("middlename2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname = If(Not IsDBNull(data.Rows(0)("lastname2")), data.Rows(0)("lastname2"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex = If(Not IsDBNull(data.Rows(0)("sex1")), data.Rows(0)("sex1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(data.Rows(0)("birthdate1")), data.Rows(0)("birthdate1"), Nothing)
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(data.Rows(0)("civilstatus")), data.Rows(0)("civilstatus"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(data.Rows(0)("street")), data.Rows(0)("street"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay = If(Not IsDBNull(data.Rows(0)("barangay")), data.Rows(0)("barangay"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(data.Rows(0)("city")), data.Rows(0)("city"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(data.Rows(0)("phonenumber1")), data.Rows(0)("phonenumber1"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Nationality = If(Not IsDBNull(data.Rows(0)("nationality")), data.Rows(0)("nationality"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Email = If(Not IsDBNull(data.Rows(0)("email")), data.Rows(0)("email"), "")
                    consultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(data.Rows(0)("FK_emdPatients")), data.Rows(0)("FK_emdPatients"), Nothing)
                    consultation.Prescriptions = New List(Of Prescription)
                    Dim prescriptionController As New PrescriptionController
                    consultation.Prescriptions = prescriptionController.GetPatientPrescribeMeds_Consulation(consultation.Consultation_ID)
                    consultation.Diagnostics = New Diagnostics
                    Dim diagnosticController As New DiagnosticsController
                    consultation.Diagnostics = diagnosticController.GetPatientCertainDiagnostics_Consultation(consultation.Consultation_ID)
                    Dim ffConsultation As New FollowUpConsultationController
                    consultation.FollowUpConsultation = ffConsultation.GetCertainConsultations_FollowUpConsultations(consultation.Consultation_ID)
                    consultation.ERTraigeForm = Me.GetPatientERCharts(consultation)
                    consultation.ERDoctorsOrder = Me.GetPatientDoctorOrder(consultation)
                    consultation.NurseNotes = Me.GetPatientNurseNotes(consultation)
                    consultation.ProgressNotes = Me.GetProgressNotes(consultation.Consultation_ID)
                    consultation.ProcedureConsent = Me.GetProceduresConsent(consultation)
                    Return consultation
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientFollowUpConsultations(consultation As CustomerConsultation) As List(Of FollowUpConsultation)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[followupconsultation]
                               WHERE consultation_id = @ID"
            cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim followUps As New List(Of FollowUpConsultation)
                If data.Rows.Count > 0 Then
                    For Each row As DataRow In data.Rows
                        Dim followUp As New FollowUpConsultation
                        followUp.FollowUp_ID = row("ff_id")
                        followUp.Consultation_Date = row("consultationdate")
                        followUp.ConsultationClinic = row("consultationclinic")
                        followUp.Consultation_ID = row("consultation_id")
                        followUps.Add(followUp)
                    Next
                    Return followUps
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientDisposition(consultation As CustomerConsultation) As CustomerConsultation
        Try
            Dim cmdCaseDispo As New SqlCommand
            cmdCaseDispo.CommandText = "SELECT [transferredreferred],[refusedadmission],[erdeath],[discharged],[forfollowup],[absconed],[hamadam],[doa],[admitted],[admittedroom],[admittedward],[admissionprogressnote],[admissiondoctororder],[admissionremarks] FROM [dbo].[customervitals] WHERE consultation_id = @ID"
            cmdCaseDispo.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdCaseDispo).Tables(0)
            If Not IsNothing(data) Then
                Dim caseDispo As New CustomerConsultation
                If data.Rows.Count > 0 Then
                    caseDispo.TransferredReferred = If(Not IsDBNull(data.Rows(0)("transferredreferred")), data.Rows(0)("transferredreferred"), 0)
                    caseDispo.RefusedAdmission = If(Not IsDBNull(data.Rows(0)("refusedadmission")), data.Rows(0)("refusedadmission"), 0)
                    caseDispo.ERDeath = If(Not IsDBNull(data.Rows(0)("erdeath")), data.Rows(0)("erdeath"), 0)
                    caseDispo.Discharged = If(Not IsDBNull(data.Rows(0)("discharged")), data.Rows(0)("discharged"), 0)
                    caseDispo.ForFollowUp = If(Not IsDBNull(data.Rows(0)("forfollowup")), data.Rows(0)("forfollowup"), 0)
                    caseDispo.Absconed = If(Not IsDBNull(data.Rows(0)("absconed")), data.Rows(0)("absconed"), 0)
                    caseDispo.HAMADAMA = If(Not IsDBNull(data.Rows(0)("hamadam")), data.Rows(0)("hamadam"), 0)
                    caseDispo.DOA = If(Not IsDBNull(data.Rows(0)("doa")), data.Rows(0)("doa"), 0)
                    caseDispo.Admitted = If(Not IsDBNull(data.Rows(0)("admitted")), data.Rows(0)("admitted"), 0)
                    caseDispo.RoomAdmitted = If(Not IsDBNull(data.Rows(0)("admittedroom")), data.Rows(0)("admittedroom"), "")
                    caseDispo.WardAdmitted = If(Not IsDBNull(data.Rows(0)("admittedward")), data.Rows(0)("admittedward"), "")
                    caseDispo.AdmittedProgressNote = If(Not IsDBNull(data.Rows(0)("admissionprogressnote")), data.Rows(0)("admissionprogressnote"), "")
                    caseDispo.AdmittedDoctorsOrder = If(Not IsDBNull(data.Rows(0)("admissiondoctororder")), data.Rows(0)("admissiondoctororder"), "")
                    caseDispo.AdmittedRemarks = If(Not IsDBNull(data.Rows(0)("admissionremarks")), data.Rows(0)("admissionremarks"), "")
                    Dim followupController As New FollowUpConsultationController
                    caseDispo.FollowUpConsultation = followupController.GetPatientFollowUpConsultations(consultation)
                End If
                Return caseDispo
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function UpdateCaseDisposition(consultation As CustomerConsultation) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            Dim deleteFFConsultation As New SqlCommand
            deleteFFConsultation.CommandText = "DELETE FROM [dbo].[followupconsultation] WHERE consultation_id = @ID"
            deleteFFConsultation.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            CMDs.Add(deleteFFConsultation)
            If consultation.ForFollowUp Then
                Dim hasFFConsultation As Boolean = False
                If Not IsNothing(consultation.FollowUpConsultation) Then
                    For Each ffItem As FollowUpConsultation In consultation.FollowUpConsultation
                        hasFFConsultation = True
                        Dim cmd As New SqlCommand
                        cmd.CommandText = " INSERT INTO [dbo].[followupconsultation] ([consultationdate] ,[consultationclinic] ,[consultation_id]) VALUES (@dt, @cl,@ID)"
                        cmd.Parameters.AddWithValue("@dt", ffItem.Consultation_Date)
                        cmd.Parameters.AddWithValue("@cl", ffItem.ConsultationClinic)
                        cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                        CMDs.Add(cmd)
                    Next
                End If
            End If
            Dim updateCaseDispo As New SqlCommand
            updateCaseDispo.CommandText = "UPDATE [dbo].[customervitals]  SET [transferredreferred] = @transref, [refusedadmission] = @refadmit, [erdeath] = @erdeath, [discharged] = @disch, [forfollowup] = @ffcon, [absconed] = @abscnd, [hamadam] = @hmdm, [doa] = @doa, [admitted] = @admt, [admittedroom] = @admtrm, [admittedward] = @admtwd, [admissionprogressnote] = @admsspnote, [admissiondoctororder] = @admssdorder, [admissionremarks] = @admssrmrk WHERE consultation_id = @ID"
            updateCaseDispo.Parameters.AddWithValue("@transref", consultation.TransferredReferred)
            updateCaseDispo.Parameters.AddWithValue("@refadmit", consultation.RefusedAdmission)
            updateCaseDispo.Parameters.AddWithValue("@erdeath", consultation.ERDeath)
            updateCaseDispo.Parameters.AddWithValue("@disch", consultation.Discharged)
            updateCaseDispo.Parameters.AddWithValue("@ffcon", consultation.ForFollowUp)
            updateCaseDispo.Parameters.AddWithValue("@abscnd", consultation.Absconed)
            updateCaseDispo.Parameters.AddWithValue("@hmdm", consultation.HAMADAMA)
            updateCaseDispo.Parameters.AddWithValue("@doa", consultation.DOA)
            updateCaseDispo.Parameters.AddWithValue("@admt", consultation.Admitted)
            updateCaseDispo.Parameters.AddWithValue("@admtrm", consultation.RoomAdmitted)
            updateCaseDispo.Parameters.AddWithValue("@admtwd", consultation.WardAdmitted)
            updateCaseDispo.Parameters.AddWithValue("@admsspnote", consultation.AdmittedProgressNote)
            updateCaseDispo.Parameters.AddWithValue("@admssdorder", consultation.AdmittedDoctorsOrder)
            updateCaseDispo.Parameters.AddWithValue("@admssrmrk", consultation.AdmittedRemarks)
            updateCaseDispo.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            CMDs.Add(updateCaseDispo)
            Return excecuteMultipleCommand(CMDs)
            'Dim cmdDeleteNurseNoteItems As New SqlCommand
            'Dim whereClause As String = ""
            'For x As Integer = 0 To consultation.ProgressNotes.Count - 1
            '    If Not x = 0 Then
            '        whereClause = whereClause & " AND "
            '    End If
            '    whereClause = whereClause & "[item_id] != @ID" & x
            '    cmdDeleteNurseNoteItems.Parameters.AddWithValue("@ID" & x, consultation.ProgressNotes(x).Item_ID)
            'Next
            'If whereClause.Trim.Length > 0 Then
            '    whereClause = "AND (" & whereClause & ")"
            'End If
            'cmdDeleteNurseNoteItems.CommandText = "DELETE FROM [dbo].[progressnotes] WHERE [consultation_id] = @ID " & whereClause
            'cmdDeleteNurseNoteItems.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            'CMDs.Add(cmdDeleteNurseNoteItems)
            'For Each item As ProgressNotes In consultation.ProgressNotes
            '    Dim cmd As New SqlCommand
            '    If item.Item_ID > 0 Then
            '        cmd.CommandText = "UPDATE [dbo].[progressnotes] SET [datecreated] = GETDATE() ,[progressnote] = @prognote ,[doctorsorder] = @dorder ,[remarks] = @rmrk WHERE [item_id] = @ID"
            '        cmd.Parameters.AddWithValue("@prognote", item.ProgressNote)
            '        cmd.Parameters.AddWithValue("@dorder", item.DoctorsOrder)
            '        cmd.Parameters.AddWithValue("@rmrk", item.Remarks)
            '        cmd.Parameters.AddWithValue("@ID", item.Item_ID)
            '        CMDs.Add(cmd)
            '    Else
            '        cmd.CommandText = "INSERT INTO [dbo].[progressnotes] ([progressnote],[doctorsorder],[remarks],[consultation_id]) VALUES (@prognote,@dorder,@rmrk,@fkid)"
            '        cmd.Parameters.AddWithValue("@prognote", item.ProgressNote)
            '        cmd.Parameters.AddWithValue("@dorder", item.DoctorsOrder)
            '        cmd.Parameters.AddWithValue("@rmrk", item.Remarks)
            '        cmd.Parameters.AddWithValue("@fkid", item.ConsultationID)
            '        CMDs.Add(cmd)
            '    End If
            'Next
            'Return excecuteMultipleCommand(CMDs)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function SaveERDoctorsOrder(erDoctorsOrder As ERDoctorsOrder) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [dbo].[doctorsorderform] SET [hospitalno] = @hostno, [filelocation] = @floc WHERE [form_id] = @ID"
            cmd.Parameters.AddWithValue("@hostno", erDoctorsOrder.HospitalNo)
            cmd.Parameters.AddWithValue("@floc", erDoctorsOrder.FileLocation)
            cmd.Parameters.AddWithValue("@ID", erDoctorsOrder.Form_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SaveNurseNote(nurseNote As NurseNote) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [dbo].[nursenotes] SET [hospitalno] = @hostno, [filelocation] = @floc WHERE [form_id] = @ID"
            cmd.Parameters.AddWithValue("@hostno", nurseNote.HospitalNo)
            cmd.Parameters.AddWithValue("@floc", nurseNote.FileLocation)
            cmd.Parameters.AddWithValue("@ID", nurseNote.Form_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SaveNurseNoteItems(ID As Long, nurseNoteItem As List(Of NurseNoteItem)) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            Dim cmdDeleteNurseNoteItems As New SqlCommand
            Dim whereClause As String = ""
            For x As Integer = 0 To nurseNoteItem.Count - 1
                If Not x = 0 Then
                    whereClause = whereClause & " AND "
                End If
                whereClause = whereClause & "form_id != @ID" & x
                cmdDeleteNurseNoteItems.Parameters.AddWithValue("@ID" & x, nurseNoteItem(x).Item_ID)
            Next
            If whereClause.Trim.Length > 0 Then
                whereClause = "AND (" & whereClause & ")"
            End If
            cmdDeleteNurseNoteItems.CommandText = "DELETE FROM [dbo].[nursenotes] WHERE fk_formid = @ID " & whereClause
            cmdDeleteNurseNoteItems.Parameters.AddWithValue("@ID", ID)
            CMDs.Add(cmdDeleteNurseNoteItems)
            For Each item As NurseNoteItem In nurseNoteItem
                Dim cmd As New SqlCommand
                If item.Item_ID > 0 Then
                    cmd.CommandText = "UPDATE [dbo].[nursenotes] SET [datecreated] = @dt,[focus] = @fcus,[dataaction] = @daction,[fk_formid] = @fkid WHERE form_id = @ID"
                    cmd.Parameters.AddWithValue("@dt", item.DateCreated)
                    cmd.Parameters.AddWithValue("@fcus", item.Focus)
                    cmd.Parameters.AddWithValue("@daction", item.DataActions)
                    cmd.Parameters.AddWithValue("@fkid", item.FK_FormID)
                    cmd.Parameters.AddWithValue("@ID", item.Item_ID)
                    CMDs.Add(cmd)
                Else
                    cmd.CommandText = "INSERT INTO [dbo].[nursenotes] ([focus],[dataaction],[fk_formid]) VALUES (@fcus,@daction,@fkid)"
                    cmd.Parameters.AddWithValue("@fcus", item.Focus)
                    cmd.Parameters.AddWithValue("@daction", item.DataActions)
                    cmd.Parameters.AddWithValue("@fkid", item.FK_FormID)
                    CMDs.Add(cmd)
                End If
            Next
            If CMDs.Count > 0 Then
                Return excecuteMultipleCommand(CMDs)
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SaveERTriageFormCharts(erChart As ERTraigeForm) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [dbo].[ertriageform] SET [caseno] = @csno ,[bedno] = @bdno ,[isGCBER] = @isGCB ,[isRESPIER] = @isRESPI ,[modeofarrival] = @mdArrival ,[ambulance] = @ambu ,[timeofcall] = @toc ,[timeofdispatch] = @tod ,[levelofconsciousness] = @lvloc ,[Classification] = @clss ,[timeofarrival] = @toal ,[timeendorsedrod] = @teord ,[timeseenrod] = @tsord ,[timeendorsedunit] = @teunit ,[patientcontactno] = @ptcpno ,[watchercontactno] = @wtcpno ,[patientreligion] = @patrel ,[painscale] = @pscale ,[cbg] = @cbg ,[travelhistory] = @travelhist ,[vaccination1] = @vac1 ,[vaccination2] = @vac2 ,[vaccination3] = @vac3 ,[traigenurseonduty] = @tnsduty ,[residentphysicianonduty] = @rsphysduty ,[carriedoutby] = @cdby ,[filelocation] = @floc WHERE [form_id] = @ID"
            cmd.Parameters.AddWithValue("@csno", erChart.CaseNo)
            cmd.Parameters.AddWithValue("@bdno", erChart.BedNo)
            cmd.Parameters.AddWithValue("@isGCB", erChart.isGCB)
            cmd.Parameters.AddWithValue("@isRESPI", erChart.isRespi)
            cmd.Parameters.AddWithValue("@mdArrival", erChart.ModeOfArrival)
            cmd.Parameters.AddWithValue("@ambu", erChart.Ambulance)
            cmd.Parameters.AddWithValue("@toc", erChart.TimeOfCall)
            cmd.Parameters.AddWithValue("@tod", erChart.TimeOfDispatch)
            cmd.Parameters.AddWithValue("@lvloc", erChart.LevelOfConsciousness)
            cmd.Parameters.AddWithValue("@clss", erChart.Classification)
            cmd.Parameters.AddWithValue("@toal", erChart.TimeOfArrival)
            cmd.Parameters.AddWithValue("@teord", erChart.TimeEndorsedROD)
            cmd.Parameters.AddWithValue("@tsord", erChart.TimeSeenROD)
            cmd.Parameters.AddWithValue("@teunit", erChart.TimeEndorsedUnit)
            cmd.Parameters.AddWithValue("@ptcpno", erChart.PatientContact)
            cmd.Parameters.AddWithValue("@wtcpno", erChart.WatchersContact)
            cmd.Parameters.AddWithValue("@patrel", erChart.PatientReligion)
            cmd.Parameters.AddWithValue("@pscale", erChart.PainScale)
            cmd.Parameters.AddWithValue("@cbg", "")
            cmd.Parameters.AddWithValue("@travelhist", erChart.TravelHistory)
            cmd.Parameters.AddWithValue("@vac1", erChart.Vaccination1)
            cmd.Parameters.AddWithValue("@vac2", erChart.Vaccination2)
            cmd.Parameters.AddWithValue("@vac3", erChart.Vaccination3)
            cmd.Parameters.AddWithValue("@tnsduty", erChart.TriageOnDuty)
            cmd.Parameters.AddWithValue("@rsphysduty", erChart.RODOnDuty)
            cmd.Parameters.AddWithValue("@cdby", erChart.CarriedBy)
            cmd.Parameters.AddWithValue("@floc", erChart.FileLocation)
            cmd.Parameters.AddWithValue("@ID", erChart.Form_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SaveProceduresConsent(procConsent As ProcedureConsent) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [dbo].[procedureconsent] SET [watchergivenname] = @gn,[watchersurname] = @sn,[watcherage] = @wage,[watcherrelation] = @wrel,[procedures] = @proc,[explainedby] = @exby,[witnessname] = @wtn,[witnessaddress] = @wtadd,[interpretername] = @intn,[interpreteraddress] = @intadd,[filelocation] = @floc WHERE form_id = @ID"
            cmd.Parameters.AddWithValue("@gn", procConsent.WatchersGivenName)
            cmd.Parameters.AddWithValue("@sn", procConsent.WatchersSurName)
            cmd.Parameters.AddWithValue("@wage", procConsent.WatchersAge)
            cmd.Parameters.AddWithValue("@wrel", procConsent.WatchersRelationship)
            cmd.Parameters.AddWithValue("@proc", procConsent.Procedures)
            cmd.Parameters.AddWithValue("@exby", procConsent.ExplainedBy)
            cmd.Parameters.AddWithValue("@wtn", procConsent.WitnessName)
            cmd.Parameters.AddWithValue("@wtadd", procConsent.WitnessAddress)
            cmd.Parameters.AddWithValue("@intn", procConsent.InterpreterName)
            cmd.Parameters.AddWithValue("@intadd", procConsent.InterpreterAddress)
            cmd.Parameters.AddWithValue("@floc", procConsent.FileLocation)
            cmd.Parameters.AddWithValue("@ID", procConsent.Form_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function GetPatientDoctorOrder(consultation As CustomerConsultation) As ERDoctorsOrder
        Try
            Dim cmdFindDoctorsOrder As New SqlCommand
            cmdFindDoctorsOrder.CommandText = "SELECT * FROM [dbo].[doctorsorderform] WHERE consultation_id = @ID"
            cmdFindDoctorsOrder.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindDoctorsOrder).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim DoctorOrder As New ERDoctorsOrder
                    DoctorOrder.Form_ID = data.Rows(0)("form_id")
                    DoctorOrder.DateCreated = data.Rows(0)("datecreated")
                    DoctorOrder.HospitalNo = If(Not IsDBNull(data.Rows(0)("hospitalno")), data.Rows(0)("hospitalno"), "")
                    DoctorOrder.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                    DoctorOrder.Consultation_ID = data.Rows(0)("consultation_id")
                    Return DoctorOrder
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientDoctorOrder_CreateInitialDoctorsOrder(consultation As CustomerConsultation) As ERDoctorsOrder
        Try
            Dim cmdFindDoctorsOrder As New SqlCommand
            cmdFindDoctorsOrder.CommandText = "SELECT * FROM [dbo].[doctorsorderform] WHERE consultation_id = @ID"
            cmdFindDoctorsOrder.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindDoctorsOrder).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdCreateDoctorsOrder As New SqlCommand
                    cmdCreateDoctorsOrder.CommandText = "INSERT INTO [dbo].[doctorsorderform] ([consultation_id]) VALUES (@ID);SELECT @@IDENTITY;"
                    cmdCreateDoctorsOrder.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                    Dim DoctorsOrderID As Long = excecuteCommandReturnID(cmdCreateDoctorsOrder)
                    If DoctorsOrderID > 0 Then
                        cmdFindDoctorsOrder = New SqlCommand
                        cmdFindDoctorsOrder.CommandText = "SELECT * FROM [dbo].[doctorsorderform] WHERE form_id = @ID"
                        cmdFindDoctorsOrder.Parameters.AddWithValue("@ID", DoctorsOrderID)
                        data = fetchData(cmdFindDoctorsOrder).Tables(0)
                        If IsNothing(data) Then
                            Return Nothing
                        ElseIf Not data.Rows.Count > 0 Then
                            Return Nothing
                        End If
                    End If
                End If
                Dim DoctorOrder As New ERDoctorsOrder
                DoctorOrder.Form_ID = data.Rows(0)("form_id")
                DoctorOrder.DateCreated = data.Rows(0)("datecreated")
                DoctorOrder.HospitalNo = If(Not IsDBNull(data.Rows(0)("hospitalno")), data.Rows(0)("hospitalno"), "")
                DoctorOrder.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                DoctorOrder.Consultation_ID = data.Rows(0)("consultation_id")
                Return DoctorOrder
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientERCharts(consultation As CustomerConsultation) As ERTraigeForm
        Try
            Dim cmdFindERForm As New SqlCommand
            cmdFindERForm.CommandText = "SELECT * FROM [dbo].[ertriageform] WHERE consultation_id = @ID"
            cmdFindERForm.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindERForm).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim ERChart As New ERTraigeForm
                    ERChart.Form_ID = data.Rows(0)("form_id")
                    ERChart.DateCreated = data.Rows(0)("datecreated")
                    ERChart.CaseNo = If(Not IsDBNull(data.Rows(0)("caseno")), data.Rows(0)("caseno"), "")
                    ERChart.BedNo = If(Not IsDBNull(data.Rows(0)("bedno")), data.Rows(0)("bedno"), "")
                    ERChart.isGCB = data.Rows(0)("isGCBER")
                    ERChart.isRespi = data.Rows(0)("isRESPIER")
                    ERChart.ModeOfArrival = If(Not IsDBNull(data.Rows(0)("modeofarrival")), data.Rows(0)("modeofarrival"), 0)
                    ERChart.Ambulance = If(Not IsDBNull(data.Rows(0)("ambulance")), data.Rows(0)("ambulance"), "")
                    ERChart.TimeOfCall = If(Not IsDBNull(data.Rows(0)("timeofcall")), data.Rows(0)("timeofcall"), Nothing)
                    ERChart.TimeOfDispatch = If(Not IsDBNull(data.Rows(0)("timeofdispatch")), data.Rows(0)("timeofdispatch"), Nothing)
                    ERChart.LevelOfConsciousness = data.Rows(0)("levelofconsciousness")
                    ERChart.TimeOfArrival = If(Not IsDBNull(data.Rows(0)("timeofarrival")), data.Rows(0)("timeofarrival"), Nothing)
                    ERChart.TimeEndorsedROD = If(Not IsDBNull(data.Rows(0)("timeendorsedrod")), data.Rows(0)("timeendorsedrod"), Nothing)
                    ERChart.TimeSeenROD = If(Not IsDBNull(data.Rows(0)("timeseenrod")), data.Rows(0)("timeseenrod"), Nothing)
                    ERChart.TimeEndorsedUnit = If(Not IsDBNull(data.Rows(0)("timeendorsedunit")), data.Rows(0)("timeendorsedunit"), Nothing)
                    ERChart.PatientContact = If(Not IsDBNull(data.Rows(0)("patientcontactno")), data.Rows(0)("patientcontactno"), "")
                    ERChart.WatchersContact = If(Not IsDBNull(data.Rows(0)("watchercontactno")), data.Rows(0)("watchercontactno"), "")
                    ERChart.PatientReligion = If(Not IsDBNull(data.Rows(0)("patientreligion")), data.Rows(0)("patientreligion"), "")
                    ERChart.PainScale = If(Not IsDBNull(data.Rows(0)("painscale")), data.Rows(0)("painscale"), 0)
                    ERChart.TravelHistory = If(Not IsDBNull(data.Rows(0)("travelhistory")), data.Rows(0)("travelhistory"), "")
                    ERChart.Vaccination1 = If(Not IsDBNull(data.Rows(0)("vaccination1")), data.Rows(0)("vaccination1"), "")
                    ERChart.Vaccination2 = If(Not IsDBNull(data.Rows(0)("vaccination2")), data.Rows(0)("vaccination2"), "")
                    ERChart.Vaccination3 = If(Not IsDBNull(data.Rows(0)("vaccination3")), data.Rows(0)("vaccination3"), "")
                    ERChart.TriageOnDuty = If(Not IsDBNull(data.Rows(0)("traigenurseonduty")), data.Rows(0)("traigenurseonduty"), "")
                    ERChart.RODOnDuty = If(Not IsDBNull(data.Rows(0)("residentphysicianonduty")), data.Rows(0)("residentphysicianonduty"), "")
                    ERChart.CarriedBy = If(Not IsDBNull(data.Rows(0)("carriedoutby")), data.Rows(0)("carriedoutby"), "")
                    ERChart.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                    ERChart.Consultation_ID = data.Rows(0)("consultation_id")
                    Return ERChart
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientERCharts_CreateInitialErChart(consultation As CustomerConsultation) As ERTraigeForm
        Try
            Dim cmdFindERForm As New SqlCommand
            cmdFindERForm.CommandText = "SELECT * FROM [dbo].[ertriageform] WHERE consultation_id = @ID"
            cmdFindERForm.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindERForm).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdCreateERCharts As New SqlCommand
                    cmdCreateERCharts.CommandText = "INSERT INTO [dbo].[ertriageform] ([isGCBER],[isRESPIER],[modeofarrival],[levelofconsciousness],[consultation_id]) VALUES (0,0,0,0,@ID);SELECT @@IDENTITY;"
                    cmdCreateERCharts.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                    Dim ERChartID As Long = excecuteCommandReturnID(cmdCreateERCharts)
                    If ERChartID > 0 Then
                        cmdFindERForm = New SqlCommand
                        cmdFindERForm.CommandText = "SELECT * FROM [dbo].[ertriageform] WHERE form_id = @ID"
                        cmdFindERForm.Parameters.AddWithValue("@ID", ERChartID)
                        data = fetchData(cmdFindERForm).Tables(0)
                        If IsNothing(data) Then
                            Return Nothing
                        ElseIf Not data.Rows.Count > 0 Then
                            Return Nothing
                        End If
                    End If
                End If
                Dim ERChart As New ERTraigeForm
                ERChart.Form_ID = data.Rows(0)("form_id")
                ERChart.DateCreated = data.Rows(0)("datecreated")
                ERChart.CaseNo = If(Not IsDBNull(data.Rows(0)("caseno")), data.Rows(0)("caseno"), "")
                ERChart.BedNo = If(Not IsDBNull(data.Rows(0)("bedno")), data.Rows(0)("bedno"), "")
                ERChart.isGCB = data.Rows(0)("isGCBER")
                ERChart.isRespi = data.Rows(0)("isRESPIER")
                ERChart.ModeOfArrival = If(Not IsDBNull(data.Rows(0)("modeofarrival")), data.Rows(0)("modeofarrival"), 0)
                ERChart.Ambulance = If(Not IsDBNull(data.Rows(0)("ambulance")), data.Rows(0)("ambulance"), "")
                ERChart.TimeOfCall = If(Not IsDBNull(data.Rows(0)("timeofcall")), data.Rows(0)("timeofcall"), Nothing)
                ERChart.TimeOfDispatch = If(Not IsDBNull(data.Rows(0)("timeofdispatch")), data.Rows(0)("timeofdispatch"), Nothing)
                ERChart.LevelOfConsciousness = data.Rows(0)("levelofconsciousness")
                ERChart.TimeOfArrival = If(Not IsDBNull(data.Rows(0)("timeofarrival")), data.Rows(0)("timeofarrival"), Nothing)
                ERChart.TimeEndorsedROD = If(Not IsDBNull(data.Rows(0)("timeendorsedrod")), data.Rows(0)("timeendorsedrod"), Nothing)
                ERChart.TimeSeenROD = If(Not IsDBNull(data.Rows(0)("timeseenrod")), data.Rows(0)("timeseenrod"), Nothing)
                ERChart.TimeEndorsedUnit = If(Not IsDBNull(data.Rows(0)("timeendorsedunit")), data.Rows(0)("timeendorsedunit"), Nothing)
                ERChart.PatientContact = If(Not IsDBNull(data.Rows(0)("patientcontactno")), data.Rows(0)("patientcontactno"), "")
                ERChart.WatchersContact = If(Not IsDBNull(data.Rows(0)("watchercontactno")), data.Rows(0)("watchercontactno"), "")
                ERChart.PatientReligion = If(Not IsDBNull(data.Rows(0)("patientreligion")), data.Rows(0)("patientreligion"), "")
                ERChart.PainScale = If(Not IsDBNull(data.Rows(0)("painscale")), data.Rows(0)("painscale"), 0)
                ERChart.TravelHistory = If(Not IsDBNull(data.Rows(0)("travelhistory")), data.Rows(0)("travelhistory"), "")
                ERChart.Vaccination1 = If(Not IsDBNull(data.Rows(0)("vaccination1")), data.Rows(0)("vaccination1"), "")
                ERChart.Vaccination2 = If(Not IsDBNull(data.Rows(0)("vaccination2")), data.Rows(0)("vaccination2"), "")
                ERChart.Vaccination3 = If(Not IsDBNull(data.Rows(0)("vaccination3")), data.Rows(0)("vaccination3"), "")
                ERChart.TriageOnDuty = If(Not IsDBNull(data.Rows(0)("traigenurseonduty")), data.Rows(0)("traigenurseonduty"), "")
                ERChart.RODOnDuty = If(Not IsDBNull(data.Rows(0)("residentphysicianonduty")), data.Rows(0)("residentphysicianonduty"), "")
                ERChart.CarriedBy = If(Not IsDBNull(data.Rows(0)("carriedoutby")), data.Rows(0)("carriedoutby"), "")
                ERChart.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                ERChart.Consultation_ID = data.Rows(0)("consultation_id")
                Return ERChart
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function


    Public Function GetPatientNurseNotes(consultation As CustomerConsultation) As NurseNote
        Try
            Dim cmdFindNurseNote As New SqlCommand
            cmdFindNurseNote.CommandText = "SELECT * FROM [dbo].[nursenotes] WHERE consultation_id = @ID"
            cmdFindNurseNote.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindNurseNote).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim NurseNote As New NurseNote
                    NurseNote.Form_ID = data.Rows(0)("form_id")
                    NurseNote.DateCreated = data.Rows(0)("datecreated")
                    NurseNote.HospitalNo = If(Not IsDBNull(data.Rows(0)("hospitalno")), data.Rows(0)("hospitalno"), "")
                    NurseNote.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                    NurseNote.Consultation_ID = data.Rows(0)("consultation_id")
                    NurseNote.NurseOrderItems = Me.GetNurseNoteItems(NurseNote.Form_ID)
                    Return NurseNote
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientNurseNotes_CreateInitialNurseNote(consultation As CustomerConsultation) As NurseNote
        Try
            Dim cmdFindNurseNote As New SqlCommand
            cmdFindNurseNote.CommandText = "SELECT * FROM [dbo].[nursenotes] WHERE consultation_id = @ID"
            cmdFindNurseNote.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindNurseNote).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdCreateNurseNote As New SqlCommand
                    cmdCreateNurseNote.CommandText = "INSERT INTO [dbo].[nursenotes] ([consultation_id]) VALUES (@ID);SELECT @@IDENTITY;"
                    cmdCreateNurseNote.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                    Dim NurseNoteId As Long = excecuteCommandReturnID(cmdCreateNurseNote)
                    If NurseNoteId > 0 Then
                        cmdFindNurseNote = New SqlCommand
                        cmdFindNurseNote.CommandText = "SELECT * FROM [dbo].[nursenotes] WHERE form_id = @ID"
                        cmdFindNurseNote.Parameters.AddWithValue("@ID", NurseNoteId)
                        data = fetchData(cmdFindNurseNote).Tables(0)
                        If IsNothing(data) Then
                            Return Nothing
                        ElseIf Not data.Rows.Count > 0 Then
                            Return Nothing
                        End If
                    End If
                End If
                Dim NurseNote As New NurseNote
                NurseNote.Form_ID = data.Rows(0)("form_id")
                NurseNote.DateCreated = data.Rows(0)("datecreated")
                NurseNote.HospitalNo = If(Not IsDBNull(data.Rows(0)("hospitalno")), data.Rows(0)("hospitalno"), "")
                NurseNote.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                NurseNote.Consultation_ID = data.Rows(0)("consultation_id")
                NurseNote.NurseOrderItems = Me.GetNurseNoteItems(NurseNote.Form_ID)
                Return NurseNote
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetNurseNoteItems(id As Long) As List(Of NurseNoteItem)
        Try
            Dim cmdFindNurseNote As New SqlCommand
            cmdFindNurseNote.CommandText = "SELECT * FROM [dbo].[nursenotes] WHERE fk_formid = @ID"
            cmdFindNurseNote.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmdFindNurseNote).Tables(0)
            If Not IsNothing(data) Then
                Dim nurseNoteItems As New List(Of NurseNoteItem)
                For Each row As DataRow In data.Rows
                    Dim nurseNoteItem As New NurseNoteItem
                    nurseNoteItem.Item_ID = row("form_id")
                    nurseNoteItem.DateCreated = row("datecreated")
                    nurseNoteItem.Focus = row("focus")
                    nurseNoteItem.DataActions = row("dataaction")
                    nurseNoteItem.FK_FormID = row("fk_formid")
                    nurseNoteItems.Add(nurseNoteItem)
                Next
                Return nurseNoteItems
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetProgressNotes(id As Long) As List(Of ProgressNotes)
        Try
            Dim cmdFindProgressNote As New SqlCommand
            cmdFindProgressNote.CommandText = "SELECT * FROM [dbo].[progressnotes] WHERE [consultation_id] = @ID"
            cmdFindProgressNote.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmdFindProgressNote).Tables(0)
            If Not IsNothing(data) Then
                Dim progressNotes As New List(Of ProgressNotes)
                For Each row As DataRow In data.Rows
                    Dim progressNote As New ProgressNotes
                    progressNote.Item_ID = row("item_id")
                    progressNote.DateCreated = row("datecreated")
                    progressNote.ProgressNote = If(Not IsNothing(row("progressnote")), row("progressnote"), "")
                    progressNote.DoctorsOrder = If(Not IsNothing(row("doctorsorder")), row("doctorsorder"), "")
                    progressNote.Remarks = If(Not IsNothing(row("remarks")), row("remarks"), "")
                    progressNote.ConsultationID = row("consultation_id")
                    progressNotes.Add(progressNote)
                Next
                Return progressNotes
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetProceduresConsent(consultation As CustomerConsultation) As ProcedureConsent
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[procedureconsent] WHERE [consultation_id] = @ID"
            cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim procConcent As New ProcedureConsent
                    procConcent.Form_ID = data.Rows(0)("form_id")
                    procConcent.DateCreated = data.Rows(0)("datecreated")
                    procConcent.WatchersGivenName = If(Not IsNothing(data.Rows(0)("watchergivenname")), data.Rows(0)("watchergivenname"), "")
                    procConcent.WatchersSurName = If(Not IsNothing(data.Rows(0)("watchersurname")), data.Rows(0)("watchersurname"), "")
                    procConcent.WatchersAge = If(Not IsNothing(data.Rows(0)("watcherage")), data.Rows(0)("watcherage"), "")
                    procConcent.WatchersRelationship = If(Not IsNothing(data.Rows(0)("watcherrelation")), data.Rows(0)("watcherrelation"), "")
                    procConcent.Procedures = If(Not IsNothing(data.Rows(0)("procedures")), data.Rows(0)("procedures"), "")
                    procConcent.ExplainedBy = If(Not IsNothing(data.Rows(0)("explainedby")), data.Rows(0)("explainedby"), "")
                    procConcent.WitnessName = If(Not IsNothing(data.Rows(0)("witnessname")), data.Rows(0)("witnessname"), "")
                    procConcent.WitnessAddress = If(Not IsNothing(data.Rows(0)("witnessaddress")), data.Rows(0)("witnessaddress"), "")
                    procConcent.InterpreterName = If(Not IsNothing(data.Rows(0)("interpretername")), data.Rows(0)("interpretername"), "")
                    procConcent.InterpreterAddress = If(Not IsNothing(data.Rows(0)("interpreteraddress")), data.Rows(0)("interpreteraddress"), "")
                    procConcent.FileLocation = If(Not IsNothing(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                    procConcent.Consultation_ID = data.Rows(0)("consultation_id")
                    Return procConcent
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetProceduresConsent_CreateProceduresConsent(consultation As CustomerConsultation) As ProcedureConsent
        Try
            Dim cmdFindProceduresConsent As New SqlCommand
            cmdFindProceduresConsent.CommandText = "SELECT * FROM [dbo].[procedureconsent] WHERE [consultation_id] = @ID"
            cmdFindProceduresConsent.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmdFindProceduresConsent).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdCreateProceduresConsent As New SqlCommand
                    cmdCreateProceduresConsent.CommandText = "INSERT INTO [dbo].[procedureconsent] ([consultation_id]) VALUES (@ID);SELECT @@IDENTITY;"
                    cmdCreateProceduresConsent.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                    Dim NurseNoteId As Long = excecuteCommandReturnID(cmdCreateProceduresConsent)
                    If NurseNoteId > 0 Then
                        cmdFindProceduresConsent = New SqlCommand
                        cmdFindProceduresConsent.CommandText = "SELECT * FROM [dbo].[procedureconsent] WHERE form_id = @ID"
                        cmdFindProceduresConsent.Parameters.AddWithValue("@ID", NurseNoteId)
                        data = fetchData(cmdFindProceduresConsent).Tables(0)
                        If IsNothing(data) Then
                            Return Nothing
                        ElseIf Not data.Rows.Count > 0 Then
                            Return Nothing
                        End If
                    End If
                End If
                Dim procConcent As New ProcedureConsent
                procConcent.Form_ID = data.Rows(0)("form_id")
                procConcent.DateCreated = data.Rows(0)("datecreated")
                procConcent.WatchersGivenName = If(Not IsDBNull(data.Rows(0)("watchergivenname")), data.Rows(0)("watchergivenname"), "")
                procConcent.WatchersSurName = If(Not IsDBNull(data.Rows(0)("watchersurname")), data.Rows(0)("watchersurname"), "")
                procConcent.WatchersAge = If(Not IsDBNull(data.Rows(0)("watcherage")), data.Rows(0)("watcherage"), 0)
                procConcent.WatchersRelationship = If(Not IsDBNull(data.Rows(0)("watcherrelation")), data.Rows(0)("watcherrelation"), "")
                procConcent.Procedures = If(Not IsDBNull(data.Rows(0)("procedures")), data.Rows(0)("procedures"), "")
                procConcent.ExplainedBy = If(Not IsDBNull(data.Rows(0)("explainedby")), data.Rows(0)("explainedby"), "")
                procConcent.WitnessName = If(Not IsDBNull(data.Rows(0)("witnessname")), data.Rows(0)("witnessname"), "")
                procConcent.WitnessAddress = If(Not IsDBNull(data.Rows(0)("witnessaddress")), data.Rows(0)("witnessaddress"), "")
                procConcent.InterpreterName = If(Not IsDBNull(data.Rows(0)("interpretername")), data.Rows(0)("interpretername"), "")
                procConcent.InterpreterAddress = If(Not IsDBNull(data.Rows(0)("interpreteraddress")), data.Rows(0)("interpreteraddress"), "")
                procConcent.FileLocation = If(Not IsDBNull(data.Rows(0)("filelocation")), data.Rows(0)("filelocation"), "")
                procConcent.Consultation_ID = data.Rows(0)("consultation_id")
                Return procConcent
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

End Class
