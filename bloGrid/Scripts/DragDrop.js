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

        panelJSON = {
                        "type": "youtube",
                        "url": url
                    };

        
        $("Content").replaceWith($.post("/Home/NewPanel", panelJSON));
        

        //alert("Added Youtube video:" + url)
    }
}

function handleFacebook() { }
function handleInstagram() { }
function handleRss() { }
function handleTwitter() { }

