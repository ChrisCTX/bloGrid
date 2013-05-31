/////////////////////////////////////////////////////////////
// This Script will handle bloGrid's drag and drop feature //
// for the panel selection part of the site                //
/////////////////////////////////////////////////////////////



// We add the draggable behavior to our icons
// limiting them to only move inside a certain DOM element
$('.panel').draggable({
    containment: '#container',
    cursor: 'move',
    revert: true
});


// And allow them to be dropped
// calling a function once they do
$("#Content").droppable({
    accept: '.panel',
    hoverClass: 'hovered',
    drop: handleCardDrop
});


// A simple key/value object that will dispatch the
// correct handler to perform according to the icon selected
var DraggableFunction = {
    "youtube": handleYoutube,
    "facebook": handleFacebook,
    "instagram": handleInstagram,
    "rss": handleRss,
    "twitter": handleTwitter
};


// We handle the drop, assert the correct ids 
// and call the specific handler for the icon
function handleCardDrop(event, ui) {
    var draggableId = ui.draggable.attr("id");
    var droppableId = $(this).attr("id");
    if (droppableId == "Content") {
        DraggableFunction[draggableId]();
    }
}


// This handlers should be self explanitory based on their names
// They prompt the user for the required information to create
// their panel inside the grid, some may feature optional info
// and create the object (in JSON) to send to the controller 
// Example: youtube asks for the video's url

function handleYoutube() {
    var url = prompt("Please enter the Youtube url");
    if (url != null && url != "") {
        if (validateURL(url))
        {
            panelJSON = {
                "type": "youtube",
                "url": url
            };
            sendPanel(panelJSON);
        }
    }
}

function handleFacebook() {
    var url = prompt("Please enter the Facebook profile url");
    if (url != null && url != "") {
        if (validateURL(url)) {
            panelJSON = {
                "type": "facebook",
                "url": url
            };
            sendPanel(panelJSON);
        }
    }
}

function handleInstagram() {
    var url = prompt("Please enter the embedd url from snapwidget.com");
    if (url != null && url != "") {
        if (validateURL(url)) {
            panelJSON = {
                "type": "instagram",
                "url": url
            };
            sendPanel(panelJSON);
        }
    }
}

function handleRss() {
    var url = prompt("Please enter the RSS url");
    if (url != null && url != "") {
        if (validateURL(url)) {
            panelJSON = {
                "type": "rss",
                "url": url
            };
            sendPanel(panelJSON);
        }
    }
}
function handleTwitter() {
    alert("Twitter feature under construction");
}

function sendPanel(panel)
{
    $.ajax({
        type: "GET",
        url: "/Home/NewPanel",
        data: $.param({ q: JSON.stringify(panel) }),
        contentType: 'text',
        dataType: 'text'
    });
}

function validateURL(value) {
    return /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(value);
}