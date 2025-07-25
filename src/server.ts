import express from 'express'
import router from './routes/index.ts'
const app = express()

// Routing
app.use('/api/', router)


export default app;