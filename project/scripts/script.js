
const goals = [
    { name: "Leitura Diária", points: 10 },
    { name: "Exercícios Físicos", points: 20 },
    { name: "Estudar Programação", points: 15 }
];


const goalsButton = document.querySelector("#showGoals");
const goalsList = document.querySelector("#goalsList");
const titleElement = document.querySelector("h2");


function updateWelcomeMessage() {
    const message = "Welcome to Eternal Quest";
    if (titleElement) {
        titleElement.textContent = message;
    }
}


function displayGoals() {

    goalsList.innerHTML = "";

    const ul = document.createElement("ul");


    goals.forEach(goal => {
        const li = document.createElement("li");

        li.textContent = `Atividade: ${goal.name} - Valor: ${goal.points} pontos`;
        ul.appendChild(li);
    });

    goalsList.appendChild(ul);
}


if (goalsButton) {
    goalsButton.addEventListener("click", displayGoals);
}


function handleStorage() {
    const user = "João Victor";
    localStorage.setItem("username", user);
    const savedUser = localStorage.getItem("username");
    console.log(`Usuário ${savedUser} conectado.`);
}


updateWelcomeMessage();
handleStorage();