const API_URL = "http://localhost:5242/api/eszkozok"

const eszkozokLekerdezese = () => {

    fetch(API_URL)
    .then(response => response.json())
    .then(adatok => {

        const tabla = document.querySelector('#eszkozTable')
        tabla.innerHTML = ''
        
        adatok.forEach(eszkoz => {
        
            tabla.innerHTML += `
                <tr>
                    <td>${eszkoz.id}</td>
                    <td>${eszkoz.nev}</td>
                    <td>${eszkoz.leltariSzam}</td>
                    <td>${eszkoz.kategoria}</td>
                    <td>${eszkoz.gyardo}</td>
                    <td>${eszkoz.terem}</td>
                    <td>${eszkoz.allapot}</td>
                    
                </tr>
            
            `

        });
    
    })
        
        
    .catch(error => {
        console.log(error);

        document.getElementById("uzenet").innerHTML = 
            '<div class=" alert alert-danger">Nem sikerült csatlakozni</div>'

    })
        


}
// addEventListner segítségével figyelünk egy felhasználói eseményt.
// Hogyha beövetkezik ez az esemyény (kattintás), akkor utána meghív 
// egy függvényt az addEventListener -> eszkozlekerdezese. 
document.getElementById("lekerdezesgomb")
    .addEventListener("click",eszkozokLekerdezese)


