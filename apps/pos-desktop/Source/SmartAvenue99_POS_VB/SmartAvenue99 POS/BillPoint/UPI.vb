Imports System
Imports System.Drawing
Imports QRCoder

Namespace BillPoint
	' Token: 0x020005FD RID: 1533
	Public Class UPI
		' Token: 0x06012ACF RID: 76495 RVA: 0x00ABA3EC File Offset: 0x00AB85EC
		Private Shared Function GetPaymentURL(vpa As String, payeeName As String, Optional txnId As String = "", Optional amount As Double? = Nothing, Optional currencyCode As String = "INR", Optional txnNote As String = "") As String
			Dim flag As Boolean = amount Is Nothing
			Dim text As String
			If flag Then
				text = String.Format("upi://pay?cu={0}&pa={1}&pn={2}&tr={3}&am=0&mode=01&purpose=10&orgid=-&sign=-&tn={4}", New Object() { currencyCode, vpa, payeeName, txnId, txnNote })
			Else
				text = String.Format("upi://pay?cu={0}&pa={1}&pn={2}&tr={3}&am={4}&mode=01&purpose=10&orgid=-&sign=-&tn={5}", New Object() { currencyCode, vpa, payeeName, txnId, amount, txnNote })
			End If
			Return text
		End Function

		' Token: 0x06012AD0 RID: 76496 RVA: 0x00ABA468 File Offset: 0x00AB8668
		Public Shared Function Generate(bank As Bank) As Bitmap
			Dim qrcodeGenerator As QRCodeGenerator = New QRCodeGenerator()
			Dim qrcodeData As QRCodeData = qrcodeGenerator.CreateQrCode(UPI.GetPaymentURL(String.Format("{0}@{1}.ifsc.npci", bank.AccountNo, bank.IfscCode), bank.PayeeName, "", bank.Amount, "INR", bank.TxnNote), QRCodeGenerator.ECCLevel.Q, False, False, QRCodeGenerator.EciMode.[Default], -1)
			Dim qrcode As QRCode = New QRCode(qrcodeData)
			Return qrcode.GetGraphic(20)
		End Function

		' Token: 0x06012AD1 RID: 76497 RVA: 0x00ABA4D8 File Offset: 0x00AB86D8
		Public Shared Function Generate(vpa As VPA) As Bitmap
			Dim qrcodeGenerator As QRCodeGenerator = New QRCodeGenerator()
			Dim qrcodeData As QRCodeData = qrcodeGenerator.CreateQrCode(UPI.GetPaymentURL(vpa.VpaId, vpa.PayeeName, "", vpa.Amount, "INR", vpa.TxnNote), QRCodeGenerator.ECCLevel.Q, False, False, QRCodeGenerator.EciMode.[Default], -1)
			Dim qrcode As QRCode = New QRCode(qrcodeData)
			Return qrcode.GetGraphic(20)
		End Function
	End Class
End Namespace
