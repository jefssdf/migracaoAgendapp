const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '/index', component: () => import('pages/IndexPage.vue'), name: 'index' }, 
      { path: '/cadastro-cliente', component: () => import('pages/cadastro-cliente.vue'), name: 'cadastro-cliente' }, 
      { path: '/lista-clientes', component: () => import('pages/lista-clientes.vue'), name: 'lista-clientes' }
    ]
  },

  {
    path: '/LoginInicio',
    component: () => import('layouts/LoginLayout.vue'),
    children: [
      { path: '/LoginInicio', name: 'Login', component: () => import('src/pages/login-inicio.vue') }

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
