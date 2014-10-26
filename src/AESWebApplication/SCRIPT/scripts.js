<!--
/*
//////////////////////////////////////////////////
//		CHANGESTYLE - by Jakob Lund Krarup		//
//////////////////////////////////////////////////
This method will change the CSS class name
of an HTML item.
The name gets the text "_hover" appended 
when the mouse moves over the item,
and the name has the text "_hover" removed
from the class name when the mouse moves out again.

CROSSBROWSER:
Made this work with FireFox after reading:
http://www.oreillynet.com/pub/a/javascript/synd/2001/09/25/event_models.html?page=2
*/
function changeStyle(evt)
{
	//Crossbrowser - get the event as a parameter (FireFox)
	//or as the windows event (IE)
	var theEvent =  evt || window.event;
	//Crossbrowser - get the HTML element that fired this event
	//as either target (FireFox) or srcElement (IE)
	var theEventSource = theEvent.target || theEvent.srcElement;
				
	//according to the event type
	//...switch the CSS class of the element
	
	switch(theEvent.type)
	{
	 
		//if the event that invoked this method
		//was a mouseover event
		case "mouseover" :
			//then we add "_hover" to the class name
			theEventSource.className  += "_hover";
			break;
						
		//otherwise - if this was a mouseout event...
		case "mouseout"  : 
			//then we remove the "_hover" from the class name	
			theEventSource.className = 
				theEventSource.className.replace("_hover", "");
	}
}

function EnableDisableOnCheckBoxClick(objChk,toDisableCtrlId)
{  

  if(objChk.checked){
       document.getElementById(toDisableCtrlId).disabled=false;            
  }
  else{
       document.getElementById(toDisableCtrlId).disabled=true;       
  }
     debugger;
  var theLabel = document.getElementById('<%=uxPreviousSchoolEducationWizardUC.FindControl("tblPreviousEducation").ClientID %>');
 
  return false;
}


-->

         


    
