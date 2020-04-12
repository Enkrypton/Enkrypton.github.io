document.getElementById("text").oninput = function() {
    document.getElementById("charlen").innerHTML = document.getElementById("text").value.length;
};

document.getElementById("PepeLaugh").onclick = async function() {
    let text = document.getElementById("text").value;
    let speak = await fetch("https://api.streamelements.com/kappa/v2/speech?voice=Brian&text=" + encodeURIComponent(text.trim()));

    if (speak.status != 200) {
        alert(await speak.text());
        return;
    }

    let mp3 = await speak.blob();

    let blobUrl = URL.createObjectURL(mp3);
    document.getElementById("source").setAttribute("src", blobUrl);
    let audio = document.getElementById("audio");
    audio.pause();
    audio.load();
    audio.play();
};

document.getElementById("copyButton").onclick = async function() {
	var copyText = document.getElementById("text");

	copyText.select();
	copyText.setSelectionRange(0, 99999);
	document.execCommand("copy");
	alert("Copied to clipboard");
};