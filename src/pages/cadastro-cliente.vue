<template>
  <div class="q-pa-md" style="max-width: 400px">
    <h1 class="text-h6">Cadastro de Cliente</h1>

    <q-form @submit="onSubmit" @reset="onReset" class="q-gutter-md">
      <q-input
        filled
        v-model="fullName"
        label="Nome Completo *"
        hint="Nome e Sobrenome"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Por favor, digite algo']"
      />

      <q-input
        filled
        v-model="contact"
        label="Contato"
        lazy-rules
      />

      <q-input
        filled
        type="email"
        v-model="email"
        label="Email *"
        lazy-rules
        :rules="[ val => /\S+@\S+\.\S+/.test(val) || 'Por favor, digite um email válido']"
      />

      <q-input
        filled
        type="password"
        v-model="password"
        label="Senha *"
        lazy-rules
        :rules="[ val => val && val.length >= 8 || 'A senha deve conter pelo menos 8 caracteres']"
      />

      <q-input
        filled
        type="password"
        v-model="confirmPassword"
        label="Confirmar Senha *"
        lazy-rules
        :rules="[ val => val === password || 'As senhas não coincidem']"
      />

      <q-toggle v-model="accept" label="Eu aceito os termos e licença" />

      <div>
        <q-btn label="Enviar" type="submit" color="primary"/>
        <q-btn label="Limpar" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>
  </div>
</template>

<script>
import { ref } from 'vue'
import axios from 'axios'

export default {
  setup () {
    const fullName = ref(null)
    const contact = ref(null)
    const email = ref(null)
    const password = ref(null)
    const confirmPassword = ref(null)
    const accept = ref(false)

    const onSubmit = async () => {
      if (accept.value !== true) {
        console.log('Você precisa aceitar os termos e licença primeiro')
      } else {
        try {
          const response = await axios.post('https://65ff33d3df565f1a6144de0b.mockapi.io/lista-clientes', {
            name: fullName.value,
            email: email.value,
            password: password.value,
            phoneNumber: contact.value
          })

          console.log('Cliente cadastrado com sucesso!', response.data)
          onReset()
        } catch (error) {
          console.error('Erro ao cadastrar cliente', error)
        }
      }
    }

    const onReset = () => {
      fullName.value = null
      contact.value = null
      email.value = null
      password.value = null
      confirmPassword.value = null
      accept.value = false
    }

    return {
      fullName,
      contact,
      email,
      password,
      confirmPassword,
      accept,
      onSubmit,
      onReset
    }
  }
}
</script>
