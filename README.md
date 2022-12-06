<p align="center" width="100%">
    <img width="55%" src="/TrabalhoFinal_POO2/Assets/Intro/Intro_Movie/Menu_Panel.png">
</p>

Princess Rampage foi um jogo produzido para o trabalho final da disciplina Programação Orientada a Objetos II, ministrada pelo professor Phyllipe Lima.
O jogo é um 2D Top-Down Wave-Based Shooter que foi produzido por meio da engine Unity e escrito em C#. 
Este trabalho possui um grande foco na utilização de Design Patterns.

# 🐱‍💻 Instalação

O arquivo executável do jogo pode ser baixado no link a seguir : [Princess Rampage](https://vivinat-corporation.itch.io/princess-rampage). 
Apesar de ser possível jogá-lo a partir do download do repositório, o arquivo deverá ser aberto na [Unity versão 2021.3.3f1](https://unity.com/releases/editor/whats-new/2021.3.3), e pode ser jogado no modo de PlayTest ou numa build separada.

# 👾 Sobre o Jogo

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
- Sistema de Score e HighScore no EndlessMode

# 🧠 As Design Patterns

Foram utilizadas as seguintes Design Patterns no processo de desenvolvimento do jogo:

## 🦥 Singleton
O Singleton é um padrão de projeto criacional, que garante que apenas um objeto desse tipo exista e forneça um único ponto de acesso a ele para qualquer outro código. O Singleton tradicionalmente é definido na função Awake (Função executada na inicialização de objetos do jogo). Destacam-se no projeto, o uso dos Singletons Game_Controller e AudioManager, o primeiro sendo responsável pela condução e armazenamento de funções e dados que dizem respeito ao player (Atributos e funções que envolvem suas manipulações), e o segundo, responsável pela reprodução e controle de efeitos sonoros do jogo.

````
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GameObject);
            return;
        }
    }
````


## 🤖 Finite State Machine (FSM)
A Finite State Machine é um sistema de comportamentos definido por Enums, o que permite a criação a troca rápida entre comportamentos. A FSM foi utilizada para o desenvolvimento da IA dos inimigos.


## 👀 Observer

## 🚧 Concurrency (Corrotinas)

# ❤ Créditos e Agradecimentos
Agradecimentos especiais para os artistas que compartilharam suas artes:

🤝 [FlandreScarlet64](https://flandrescarlet64.itch.io/16x16-16-bits-top-down-mage-character)     
🤙 [3xBlast](https://opengameart.org/content/16bit-boss-battle-loop)  
👍 [Spring Spring](https://opengameart.org/content/the-king-of-hell-final-boss-theme)  
💗 [jkfite01](https://opengameart.org/content/peaceful-village-16-bit)  
💪 [Redshrike](https://opengameart.org/content/16x16-16x24-32x32-rpg-enemies-updated)  
🙏 [request](https://opengameart.org/content/their-spears-fell-like-rain-loopable-chiptune-battle-theme)  
🤜 [RedSteve](https://redsteve.itch.io/top-down-dungeon-tileset)  

Quaisquer outras artes que não foram aqui citadas foram produzidas de forma original ou, se sua arte foi usada, peço que entre em contato para que possa ser fornecido os devidos créditos.

#  Autores
🌸[Vinicius Vieira Mota](https://github.com/Vivinat)


🎮👨‍🦲 Projeto desenvolvido para a disciplina POO2 do Professor [Phyllipe Lima](https://github.com/phillima). 




