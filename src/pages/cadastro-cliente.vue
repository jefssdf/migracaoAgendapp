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
        type="date"
        v-model="birthDate"
        label="Data de Nascimento *"
        lazy-rules
        :rules="[ val => val !== null && val !== '' || 'Por favor, digite sua data de nascimento']"
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
import { useQuasar } from 'quasar'
import { ref } from 'vue'

export default {
  setup () {
    const $q = useQuasar()

    const fullName = ref(null)
    const birthDate = ref(null)
    const contact = ref(null)
    const email = ref(null)
    const password = ref(null)
    const confirmPassword = ref(null)
    const accept = ref(false)

    return {
      fullName,
      birthDate,
      contact,
      email,
      password,
      confirmPassword,
      accept,

      onSubmit () {
        if (accept.value !== true) {
          console.log('Você precisa aceitar os termos e licença primeiro')
        } else {
          console.log('Enviado')
        }
      },

      onReset () {
        fullName.value = null
        birthDate.value = null
        contact.value = null
        email.value = null
        password.value = null
        confirmPassword.value = null
        accept.value = false
      }
    }
  }
}
</script>
