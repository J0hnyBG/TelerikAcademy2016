"use strict";
window.onload = function () {
    let googleMapsButton = document.getElementById('map-link');

//Task 1
    function renderPosition(position) {
        let mapImage = document.getElementById('map-image');
        mapImage.src = `https://maps.googleapis.com/maps/api/staticmap?center=${position.coords.latitude},${position.coords.longitude}"&zoom=13&size=600x600&markers=color:red%7Clabel:C%7C${position.coords.latitude},${position.coords.longitude}&key=AIzaSyB0gs6LCbo-AgaZruywKaP-fPCiBF5DBjA`;

        document.getElementsByClassName('location')[0].innerHTML = `${position.coords.latitude}, ${position.coords.longitude}`;

        googleMapsButton.href = `https://www.google.bg/maps/dir/${position.coords.latitude},${position.coords.longitude}//@${position.coords.latitude},${position.coords.longitude},16.0z`;
    }

    function showError(err) {
        alert(err.message);
    }

    let promise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    })
        .then(renderPosition)
        .catch(showError);

//Task 2
    let cancelButton = document.createElement('a');
    cancelButton.innerHTML = "Cancel";
    cancelButton.href = '#';
    cancelButton.className = 'btn';

    let para = document.createElement('p');
    para.appendChild(cancelButton);

    let infoBox = document.createElement('div');
    infoBox.innerHTML = "Redirecting you to https://www.google.bg/maps/ in two seconds.";
    infoBox.className = 'info';
    infoBox.appendChild(para);

    let popupWrapper = document.createElement('div');
    popupWrapper.className = 'popup hidden';
    popupWrapper.appendChild(infoBox);

    document.body.appendChild(popupWrapper);

    googleMapsButton.onclick = ev => {
        ev.preventDefault();
        ev.stopPropagation();

        popupWrapper.className = 'popup';

        let promise = new Promise((resolve, reject) => {
                cancelButton.onclick = event => {
                    event.preventDefault();
                    event.stopPropagation();
                    reject({message: "You cancelled the transfer to Google Maps! Promise has been rejected!"});
                };

                setTimeout(() => {
                    resolve(ev);
                }, 2000);
            }
        ).then(ev => {
            popupWrapper.className = 'popup hidden';
            let url = ev.target.href;
            let win = window.open(url, "_self");
            if (win) {
                win.focus();
            }
            else {
                showError({message: 'Please allow popups for this website'});
            }
        }).catch(err => {
            popupWrapper.className = 'popup hidden';
            showError(err);
        });
    }
};
