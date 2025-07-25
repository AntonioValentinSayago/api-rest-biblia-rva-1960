import type { Request, Response } from 'express';
import { obtenerLibros } from '../services/books.service.ts';

export const listarLibros = ( req: Request, res: Response) => {
    const data = obtenerLibros();
    res.status(200).json(data);
}