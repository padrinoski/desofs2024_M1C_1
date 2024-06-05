import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { Auth0Provider } from '@auth0/auth0-react'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Auth0Provider
      domain='dev-b61l3yhgpdw5l2m2.us.auth0.com'
      clientId='a8wEXjcF9dzOlaWF4iICpR0y3LMl4L3m'
      authorizationParams={{redirect_uri: `${window.location.origin}/profile`}}
    >

      <App />
    </Auth0Provider>
      
  </React.StrictMode>,
)
