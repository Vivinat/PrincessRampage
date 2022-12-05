<p align="center" width="100%">
    <img width="55%" src="/TrabalhoFinal_POO2/Assets/Intro/Intro_Movie/Menu_Panel.png">
</p>

Princess Rampage foi um jogo produzido para o trabalho final da disciplina Programação Orientada a Objetos II, ministrada pelo professor Phyllipe Lima.
O jogo é um 2D Top-Down Wave-Based Shooter que foi produzido por meio da engine Unity e escrito em C#. 
Este trabalho possui um grande foco na utilização de Design Patterns.

# Instalação

O arquivo executável do jogo pode ser baixado por meio do site "". 
Apesar de ser possível jogá-lo a partir do download do repositório, o arquivo deverá ser aberto na Unity versão 2021.3.3f1 (LTS), e pode ser jogado no modo de PlayTest
ou numa build separada.

# Sobre o Jogo

<p align="center" width="100%">
    <img width="2%" src="/TrabalhoFinal_POO2/Assets/Player_Sprites/Bald.png">
</p>



Após ter sido amaldiçoada por uma bruxa com um problema capilar (Careca), a princesa Phillima precisa realizar um ritual para impedir que seus belos cabelos caiam!
Use da magia da princesa para abater os asseclas da bruxa, e acabe com ela para finalizar o ritual!
Além das mecânicas de disparo, o jogo conta com as seguintes mecânicas:

- Timer para abater o máximo possível de inimigos e sobreviver;
- Sistema de drops que fornecem desde curas até efeitos permanentes nos atributos;
- Sistema de Level-Up aleatório;
- "Endless Mode", onde o objetivo é sobreviver o máximo de tempo possível enquanto hordas intermináveis de inimigos o atacam.

# As Design Patterns

Foram utilizadas as seguintes Design Patterns no processo de desenvolvimento do jogo:

## Singleton
O Singleton é um padrão de projeto criacional, que garante que apenas um objeto desse tipo exista e forneça um único ponto de acesso a ele para qualquer outro código. No jogo, ele foi utilizado na função *Awake* que permite chamar Game_Controller em qualquer lugar do jogo
````
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
````


## Finite State Machine (FSM)

## Observer

## Concurrency (Corrotinas)

# Créditos e Agradecimentos

