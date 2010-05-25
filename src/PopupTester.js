var spbw = false;
function showBlockerWarning() {
    return spbw;
}

function toggleVisibility(id) {
    if (document.all) {
        var messageObject = document.all[id];
        if (messageObject != null) {
            messageObject.style.display = 'block';
        }    
    } else if (document.getElementById) {
        var messageObject = document.getElementById(id);
        if (messageObject != null) {
            messageObject.style.display = 'block';
        }        
    }
}

function init() {
    spbw = detectPopupBlocker();
}

function detectPopupBlocker() {
    var child = null;
    var child2 = null;
    var e = false;
    
    try {
        do {
            var d = new Date();
            var wName = "ptest_" + d.getTime();
            var testUrl = "";
            child = window.open(testUrl, wName, "width=0,height=0,left=5000,top=5000", true);
            if (child == null || child.closed) {
                e = true;
                break;
            }
            
            child2 = window.open(testUrl, wName, "width=0,height=0");
            if (child2 == null || child2.closed) {
                e = true;
                break;
            }
            
            child.close();
            child2.close();
            child = child2 = null;
        } while (false);                    
    } catch (ex) {
        e = true;
    }
    
    if (child != null) {
        try { if (!child.closed) child.close(); } catch(ex){}
    }
    
    if (child2 != null) {
        try { if (!child2.closed) child2.close(); } catch(ex){}
    }
    
    return e;
}
