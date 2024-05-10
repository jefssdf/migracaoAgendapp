const routes = [
  {
    path: '/AgendarConsultas',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '/AgendarConsultas', name: 'AgendarConsultas', component: () => import('pages/AgendarConsultas.vue') },
      { path: '/Consultas', name: 'Consultas', component: () => import('pages/ConsultasAtendimentos.vue') }
    ]
  },
  {
    path: '/LoginInicio',
    component: () => import('layouts/LoginLayout.vue'),
    children: [
      { path: '/LoginInicio', name: 'Login', component: () => import('src/pages/LoginInicio.vue') },
      { path: '/Criar', name: 'Criar', component: () => import('pages/CriarConta.vue') }

    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    redirect: '/LoginInicio',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
