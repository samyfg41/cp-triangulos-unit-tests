# Relatorio de Bugs

**Aluno(s):** Samantha Faruolo Galdi - RM554794  **Turma:** 2TDSA  **Data:** 04/10/2026

**Aluno(s):** Agatha Yie Won Yun - RM561507  **Turma:** 2TDSA  **Data:** 04/10/2026

**Aluno(s):** Mirelly Sousa Alves - RM566299  **Turma:** 2TDSA  **Data:** 04/10/2026

**Aluno(s):** Gabriely Bonfim Silva - RM566242  **Turma:** 2TDSA  **Data:** 04/10/2026

## 1. Resumo

| Item | Valor |
|------|-------|
| Total de casos de teste escritos | 79    |
| Casos vermelhos no codigo original ("antes") | 22    |
| Casos vermelhos no codigo corrigido ("depois") | 0     |
| Cobertura de linhas (Triangulos.Core) | 100%  |
| Cobertura de ramos (Triangulos.Core) | 100%  |

## 2. Bugs encontrados

Preencha uma linha por bug. Seja especifico: "calculo errado" nao e uma descricao.

| ID | Regra violada (RN) | Sintoma (entrada -> obtido x esperado) | Local (arquivo:metodo) | Causa raiz | Correcao aplicada | Teste que prova (nome) | Commit |
|----|--------------------|----------------------------------------|------------------------|------------|-------------------|------------------------|--------|
| B01 | RN02 | (1,2,3) -> triangulo valido x NaoEhTriangulo | ClassificadorTriangulo.cs:EhTriangulo | A igualdade entre a soma de dois lados e o terceiro era aceita e uma das tres comparacoes nao era realizada | Alteradas as comparacoes para <= e adicionada a verificacao de b+c <= a | EhTriangulo_EntradasVariadas_RetornaResultadoEsperado | 147bd6f |
| B02 | RN03 | (2,3,2) -> Escaleno x Isosceles | ClassificadorTriangulo.cs:Classificar | A classificacao verificava a==b e b==c, mas nao verificava a==c | Adicionada a comparacao a==c na verificacao de Isosceles | Classificar_DoisLadosIguais_RetornaIsosceles | ff915e6 |
| B03 | RN05 | (2,2,2) -> 1,7 x 1,73 | CalculadoraTriangulo.cs:Area | A area era arredondada para apenas uma casa decimal | Alterado Math.Round de 1 para 2 casas decimais com AwayFromZero | Area_TrianguloValido_RetornaAreaPelaFormulaDeHeron | 0702d65 |
| B04 | RN06 | (5,3,4) -> angulo C incorreto x 53.13 | CalculadoraTriangulo.cs:Angulos | O denominador da lei dos cossenos para o angulo C utilizava 2*a*c em vez de 2*a*b | Corrigido o denominador do calculo do angulo C para 2*a*b | Angulos_TrianguloValido_RetornaAngulosCorretos | 91a7387 |
| B05 | RN07 | (5,3,4) -> false x true | CalculadoraTriangulo.cs:EhRetangulo | O metodo considerava sempre c como hipotenusa e utilizava igualdade exata entre doubles | O maior lado passou a ser identificado como hipotenusa e foi aplicada a tolerancia relativa de 1e-9*z² | EhRetangulo_TriangulosValidos_RetornaResultadoEsperado | 914d23f |
| B06 | Contrato da API | GET /classificar?a=3&b=4 -> 200 x 400 | Program.cs:/api/triangulos/classificar | O parametro c possuia valor padrao 0 e por isso era tratado como opcional | Removido o valor padrao de c, tornando os tres parametros obrigatorios | Classificar_ParametroAusente_Retorna400 | 72fa1d2 |
| B07 | RN01 | (NaN,2,2) -> true x false | ClassificadorTriangulo.cs:EhTriangulo | O metodo verificava apenas se os lados eram maiores que zero, sem validar explicitamente se os valores eram finitos | Adicionada a verificacao com double.IsFinite para os tres lados | EhTriangulo_LadoNaoFinito_RetornaFalse | eeab87d |

## 3. Prova de sensibilidade (pelo menos 3 bugs)

Para cada bug escolhido: reintroduza o defeito, rode o teste e cole a saida que mostra a falha; depois restaure a correcao.

| Bug | Como reintroduzi                                                            | Teste que falhou | Evidencia (arquivo em evidencias/sensibilidade/) |
|-----|-----------------------------------------------------------------------------|------------------|--------------------------------------------------|
| B02 | Removemos a comparacao a==c da verificacao de triangulo Isosceles, fazendo o codigo voltar ao comportamento original com defeito         | Classificar_DoisLadosIguais_RetornaIsosceles / Classificar_PermutacaoDosLados_MantemClassificacao | bug-01-isosceles.txt |
| B03 | Alteramos novamente o arredondamento da area de 2 para 1 casa decimal, reintroduzindo o defeito original                  | Area_TrianguloValido_RetornaAreaPelaFormulaDeHeron (2,2,2: esperado 1,73 e obtido 1,7) | bug-02-area.txt |
| B05 | Alteramos o metodo EhRetangulo para considerar novamente o lado c como hipotenusa e utilizar igualdade exata | EhRetangulo_TriangulosValidos_RetornaResultadoEsperado e testes dependentes | bug-03-retangulo.txt |

## 4. Bugs que eu NAO consegui corrigir / duvidas

Nenhum. Todos os bugs identificados foram corrigidos e a suite final ficou com 79 testes aprovados e 0 falhas.

## 5. O que aprendi

Aprendemos a usar testes para identificar a causa de bugs e validar as correções sem alterar comportamentos que ja estavam funcionando. Também conseguimos entender melhor testes de integração, cobertura de código e como os testes de regressão ajudam a evitar que um erro volte depois de uma correção.
