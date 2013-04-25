EXEC SendSqlMail 
	@recipients = 'someuser@somedomain.com', 
	@cc='', 
	@bcc='', 
	@subject = 'Subject', 
	@from = 'fromsomeone@somedomain.com', 
	@body = 'Test', 
	@attachments='', 
	@server = 'mail.somedomain.com', 
	@port = 25, 
	@user= 'smtpuser@somedomain.com', 
	@pwd = 'somepassword'