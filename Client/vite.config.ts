import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'

//npm install -D vite-plugin-mkcert serve per installare il plugin per il certificato e usare https in locale
// funziona solo durante lo sviluppo e non in produzione
import mkcert from 'vite-plugin-mkcert'

// https://vite.dev/config/
export default defineConfig({
  server: {
    port: 3000,
  },
  plugins: [
    react(), 
    mkcert()
  ],
})
