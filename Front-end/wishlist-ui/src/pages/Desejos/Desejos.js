import {Component} from 'react';

class Desejos extends Component{
    constructor(props)
    {
        super(props)
        this.state = {
            //nome do estado : valor inicial
            listaDesejos : [],
            titulo : ''
        }
    }

    buscarDesejos = () => {
        console.log('Agora faremos a chamada para a API');

        //Faz a chamada para a API usando o fetch
        fetch('http://localhost:5000/api/desejos')

        // Define o tipo de retorno da requisição em json
        .then(resposta => resposta.json())

        //Atualiza o state listaDesejos com os dados obtidos
        .then (data => this.setState({listaDesejos : data}))

        // Caso ocorra algum erro, mostra no console do navegador
        .catch ((erro) => console.log(erro))
    }

    //Chama a função buscar desejos assim que o componente é renderizado
    componentDidMount(){
            //codigo
            this.buscarDesejos();
                       }
    render(){
        return(
            <div>
                <main>
                    <section>
                        {/* Lista desejos */}
                        <h2>Lista de Desejos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th> {/*coluna da tabela*/}
                                    <th>descricao</th>
                                    <th>usuario</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    // Array
                                    this.state.listaDesejos.map((desejo) => {
                                        return (
                                            <tr key={desejo.desejoid}>
                                                <td>{desejo.desejoid}</td>
                                                <td>{desejo.descricao}</td>
                                                <td>{desejo.usuario}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                </main>
            </div>
        )
            }
}


export default Desejos;