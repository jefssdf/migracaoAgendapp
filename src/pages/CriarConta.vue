<template>
  <div class="primeira">
    <form class="form" @submit.prevent="enviarFormulario" >
      <h2 style="font-weight: bold;">Registrar</h2>
      <label>
        <span> Nome Completo </span>
        <q-input rounded outlined v-model="login" label="Digite seu Nome" />
      </label>
      <label>
        <span> Contato </span>
        <q-input rounded outlined v-model="login" label="Digite seu Contato" />
      </label>
      <label>
        <span> Email</span>
        <q-input rounded outlined v-model="login" label="Digite seu Email" />
      </label>
      <label>
        <span> Senha</span>
        <q-input type="password" rounded outlined v-model="senha" label="Digite sua Senha" />
        <span> Confirme sua senha</span>
        <q-input type="password" rounded outlined v-model="senha" label="Digite novamente sua Senha" />
      </label>
      <label>
        <span> Data de Nascimento</span>
        <div class="date-input-container">
          <q-input filled v-model="date" mask="date" :rules="['date']">
            <template v-slot:append>
              <q-icon name="event" class="cursor-pointer">
                <q-popup-proxy cover transition-show="scale" transition-hide="scale">
                  <q-date v-model="date">
                    <div class="row items-center justify-end">
                      <q-btn v-close-popup label="Enviar" color="secondary" flat text-color="white" />
                    </div>
                  </q-date>
                </q-popup-proxy>
              </q-icon>
            </template>
          </q-input>
        </div>
      </label>
      <label class="salvar-senha-label">
        <q-toggle v-model="salvarSenha" color="secondary" label="Concordo com os termos" />
      </label>
      <q-btn flat color="secondary" label="Criar" type="submit" text-color="white" @click="irParaAgendar"/>
    </form>
  </div>
</template>

<style scoped>

  .primeira {
    display: block;
    justify-content: center;
    align-items: center;
    background: #ebebeb;
    border-radius: 25px;
    width: 40%;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    top: 48%;
    margin-top: 50px;
    padding: 20px;
  }

  h2 {
    color: #17a2b8;
    padding-top: 10px;
    font-size: 30px;
    text-align: center;
    margin-bottom: 20px;
  }

  .date-input-container {
    display: flex;
    justify-content: center;
    width: 100%;
  }

  .form {
    padding: 20px 30px;
    -webkit-transition:-webkit-transform 1.2s ease-in-out;
    transition: -webkit-transform 1.2s ease-in-out;
    transition: transform 1.2s ease-in-out;
    transition: transform 1.2s ease-in-out, -webkit-transform 1.2s ease-in-out;
  }

  label {
    display: block;
    width: 100%;
    margin-bottom: 10px;
  }

  label span {
    font-size: 14px;
    font-weight: 600;
    color: #17a2b8;
    text-transform: uppercase;
  }

  input {
    display: flex;
    width: 100%;
    margin-top: 5px;
    font-size: 16px;
    padding-bottom: 5px;
    border-bottom: 1px solid rgba(185, 77, 77, 0.4);
    text-align: center;
    font-family: 'Nunito', sans-serif;
  }

  button {
    display: block;
    margin: 20px auto;
    width: 100%;
    height: 36px;
    border-radius: 30px;
    background-color: #26a69a;
    color: white;
    font-size: 15px;
    cursor: pointer;
  }

  button:hover {
    background-color: rgb(43, 233, 91);
  }

  .salvar-senha-label {
    color: rgb(64, 166, 184);
  }

  @media only screen and (max-width: 767px) {
    .primeira {
      width: 90%;
      padding-top: 80px;
    }
  }
</style>

<script>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

export default {
  setup () {
    const login = ref('')
    const senha = ref('')
    const salvarSenha = ref(false)
    const router = useRouter()

    const irParaAgendar = () => {
      router.push({ name: 'AgendarConsultas' })
    }

    const enviarFormulario = () => {
      router.push({ name: 'AgendarConsultas' })
    }

    return {
      date: ref('2024/04/10'),
      login,
      senha,
      salvarSenha,
      irParaAgendar,
      enviarFormulario
    }
  }
}
</script>
