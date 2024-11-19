import './envConfig.js'
 
export default defineConfig({
  api: {
    market: process.env.services__marketapi__https__0 ||
    process.env.services__marketapi__http__0
  },
})