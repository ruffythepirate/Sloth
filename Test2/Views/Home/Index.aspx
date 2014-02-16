<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Johans Poof of Coonept</title>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" ></script>
	</head>
<body>
	<div>
	<h1>Trying to test ajax post down to database...</h1>


	<a id="add_message" href="#">ADD</a>
		<%= Html.Encode(ViewData["Message"]) %>

		<div id="feedback">No feedback yet!</div>
	</div>

	<script>
		$('#add_message').click(function () {
					$('#feedback').val('Sending request to add message...');
			
			//We send an add request to the server.

			$.ajax({
				type : "post",
				url : "Home/AddMessage",
				data : { Message : "My Message" },
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

