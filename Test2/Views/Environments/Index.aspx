<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Johans Poof of Cooncept</title>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" ></script>
	</head>
<body>
	<div>
		<h1>Environments</h1>
	<p>
	This page tests creating new "Environment" entities in the database.
	</p>

	<form method="POST" action="/Environments/Create">
	<label type="" for="environment-name">Environment:</label> 
	<input type="text" id="environment-name" />

	<a id="add-environment" href="#">ADD</a>
		
	</form>

		<div id="feedback">No feedback yet!</div>
	</div>
	</div>


	<script>
		$('#add-environment').click(function () {
					
			$('#feedback').val('Sending request to add message...');
			
			//We send an add request to the server.

			var name = $('#environment-name').val();

			$.ajax({
				type : "post",
				url : "Environments/Create",
				data : { Name : name },
				success : function () {
					$('#feedback').val('Success!');
				},
				error : function () {
					$('#feedback').val('Error!');
				}
			});
		}); 
	</script>
</body>

	