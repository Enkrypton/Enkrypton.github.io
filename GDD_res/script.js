function generate(event) {
	//diff icon
	var e = document.getElementById("diff");
	var diff = e.options[e.selectedIndex].text;
	
	//ranked icon
	var ranked = document.querySelector('.form-check-input').checked;
	
	var mapper = document.getElementById('Mapper').value;
	var name = document.getElementById('SongName').value;
    document.getElementById('bb').value = diff + " " + name + " by " + mapper + " " + ranked;
}