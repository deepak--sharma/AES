//START----Enable or disable controlState on check box checked change
var controlState;
function EnableDisable(bEnable, toDisableControlId)
{  
    //Approach:1
    $("#"+toDisableControlId+" input").attr("disabled", !bEnable);
    $("#"+toDisableControlId+" select").attr("disabled", !bEnable);
    $("#"+toDisableControlId+" textarea").attr("disabled", !bEnable);
    
//Approach:2
//    var controls = document.getElementById(toDisableControlId).getElementsByTagName("input");
//    for (var i = 0; i < controls.length; i++)
//    {
//        controls[i].disabled = !bEnable;
//    }

//Approach:3
//    controlState = !bEnable
//    document.getElementById(toDisableControlId).disabled = !bEnable
//    DisableChildElements(toDisableControlId);   
}

function DisableChildElements(containerId)
{
    var theObject = document.getElementById(containerId);
    var level = 0;
    TraverseDOM(theObject, level, disableElement);
}

function TraverseDOM(obj, lvl, actionFunc)
{
    for (var i=0; i<obj.childNodes.length; i++) {
            var childObj = obj.childNodes[i];
            if (childObj.tagName) {
                    actionFunc(childObj);
            }
            TraverseDOM(childObj, lvl + 1, actionFunc);
    }
}

function disableElement(obj)
{
    obj.disabled = controlState;
}  
//END----Enable or disable controlState on check box checked change

//Check Uncheck all record in gridview
var TotalChkBx;
var Counter = 0;
function InitializeGridRowCounter(grid)
{        
    //Get total no. of CheckBoxes in side the GridView.
   TotalChkBx = parseInt(grid.rows.length)-1;   
}

function HeaderClick(CheckBox,gridId)
{
   var grid =  document.getElementById(gridId);
   
   InitializeGridRowCounter(grid);
   
   //Get target child control.   
   var TargetChildControl = "chkSelectItem";

   //Get all the control of the type INPUT in the base control.
   var Inputs = grid.getElementsByTagName("input");

   //Checked/Unchecked all the checkBoxes in side the GridView.
   for(var n = 0; n < Inputs.length; ++n)
      if(Inputs[n].type == 'checkbox' && 
                Inputs[n].id.indexOf(TargetChildControl,0) >= 0)
         Inputs[n].checked = CheckBox.checked;

   //Reset Counter
   Counter = CheckBox.checked ? TotalChkBx : 0;
}

function ChildClick(CheckBox, HCheckBox,gridId)
{
    var grid =  document.getElementById(gridId);
    InitializeGridRowCounter(grid);
    
   //get target control.
   var HeaderCheckBox = document.getElementById(HCheckBox);

   //Modifiy Counter; 
   if(CheckBox.checked && Counter < TotalChkBx)
      Counter++;
   else if(Counter > 0) 
      Counter--;

   //Change state of the header CheckBox.
   if(Counter < TotalChkBx)
      HeaderCheckBox.checked = false;
   else if(Counter == TotalChkBx)
      HeaderCheckBox.checked = true;
}