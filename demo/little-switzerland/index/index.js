function showNav(){
    document.getElementById('top-nav').style.display = 'flex';
    document.getElementById('close-nav-btn').style.display = 'block';
    document.getElementById('open-nav-btn').style.display = 'none';
}

function hideNav(){
    document.getElementById('top-nav').style.display = 'none';
    document.getElementById('close-nav-btn').style.display = 'none';
    document.getElementById('open-nav-btn').style.display = 'block';
}