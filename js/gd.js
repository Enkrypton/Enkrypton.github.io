function generate(event) {
	//diff icon
	var e = document.getElementById("diff");
	var diff = e.options[e.selectedIndex].text;
	
	//ranked icon
	var ranked = document.querySelector('.form-check-input').checked;
	
	var mapper = document.getElementById('Mapper').value;
	var name = document.getElementById('SongName').value;
	var map = document.getElementById('link').value;
	if (ranked){
		document.getElementById('bb').value = "[img]https://enkrypton.github.io/assets/osu_icons/"+diff+".png[/img]" + " " + "[url="+map+"]"+name+"[/url]" + " by " + "[b][profile]"+mapper+"[/profile][/b]"+" "+"[img]https://enkrypton.github.io/assets/osu_icons/Ranked.gif[/img]";
	}
	else{
		document.getElementById('bb').value = "[img]https://enkrypton.github.io/assets/osu_icons/"+diff+".png[/img]" + " " + "[url="+map+"]"+name+"[/url]" + " by " + "[b][profile]"+mapper+"[/profile][/b]";
	}

}