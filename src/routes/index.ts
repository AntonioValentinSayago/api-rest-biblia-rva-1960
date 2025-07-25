import { Router } from 'express'
import { listarLibros } from '../controllers/books.controller.ts';

const router = Router()

// Routing
router.get('/libros', listarLibros )


export default router;