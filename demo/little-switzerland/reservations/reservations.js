let queryString = window.location.search.substring(1);
let queryPieces = queryString.split("&");

for(let i = 0; i < queryPieces.length; i++){
    let queryName = queryPieces[i].split("=")[0];
    if(queryName === "cabin1"){
        document.getElementsByName("cabin1")[0].checked = true;
    }
    if(queryName === "cabin2"){
        document.getElementsByName("cabin2")[0].checked = true;
    }
    if(queryName === "cabin3"){
        document.getElementsByName("cabin3")[0].checked = true;
    }
    if(queryName === "cabin4"){
        document.getElementsByName("cabin4")[0].checked = true;
    }
    if(queryName === "cabin5"){
        document.getElementsByName("cabin5")[0].checked = true;
    }
}

