<template>
  <div class="primeira">
    <form class="form">
      <!-- Substituir o título por uma imagem -->
      <img src="https://i.ibb.co/CzzsksM/logo.png" alt="Logo"
           style="width: 350px; height: auto; margin-top: -35px; margin-bottom: -35px; display: block; margin-left: 31%; margin-right: 20%;"/>
      
      <label>
        <span> Login </span>
        <q-input
          rounded
          outlined
          v-model="login"
          label="Digite seu Email"
          :rules="[
            val => /[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+/.test(val) || 'Insira um endereço de email válido',
            val => val && val.length >= 5 || 'O email deve ter no mínimo 5 caracteres'
          ]"
        />
      </label>
      <label>
        <span> Senha</span>
        <q-input
          type="password"
          rounded
          outlined
          v-model="senha"
          label="Digite sua Senha"
          :rules="[val => !!val || 'Digite sua Senha']"
        />
      </label>
      <label class="salvar-senha-label">
        <q-toggle v-model="salvarSenha" color="secondary" label="Salvar Senha" />
      </label>
      <q-btn flat color="secondary" label="Entrar" type="button" text-color="white" @click="fazerLogin" :disabled="!formularioCompleto" />
    </form>
  </div>
</template>

<script>
import { ref, computed } from 'vue'
import { useRouter } from 'vue-router'
import { Notify } from 'quasar'

export default {
setup() {
  const login = ref('')
  const senha = ref('')
  const salvarSenha = ref(false)
  const router = useRouter()

  const fazerLogin = () => {
    // Aqui você pode realizar a lógica de autenticação, por exemplo, com uma API
    // Simulando um login bem-sucedido para demonstração
    if (login.value === 'ralf@gmail.com' && senha.value === 'senha123') {
      // Redireciona para a rota de dashboard após o login
      router.push({ name: 'index' })
    } else {
      Notify.create({
        type: 'negative',
        message: 'Usuário ou senha inválidos'
      })
    }
  }

  const formularioCompleto = computed(() => {
    return !!login.value && !!senha.value
  })

  return {
    login,
    senha,
    salvarSenha,
    formularioCompleto,
    fazerLogin
  }
}
}
</script>

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
padding: 20px;
}

h2 {
color: #17a2b8;
padding-top: 10px;
font-size: 30px;
text-align: center;
}

.form {
-webkit-transition: -webkit-transform 1.2s ease-in-out;
transition: -webkit-transform 1.2s ease-in-out;
transition: transform 1.2s ease-in-out;
transition: transform 1.2s ease-in-out, -webkit-transform 1.2s ease-in-out;
}

label {
display: block;
width: 100%;
margin: 15px auto 0;
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
}
}
</style>
