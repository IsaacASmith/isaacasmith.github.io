var navDisplayed = false;

function toggleNav(){
    if(navDisplayed) {
        document.getElementById('top-nav').style.display = 'none';
        document.getElementById('close-nav-btn').style.display = 'none';
        document.getElementById('open-nav-btn').style.display = 'block';
    }
    else {
        document.getElementById('top-nav').style.display = 'flex';
        document.getElementById('close-nav-btn').style.display = 'block';
        document.getElementById('open-nav-btn').style.display = 'none';
    }
    
    navDisplayed = !navDisplayed;
}