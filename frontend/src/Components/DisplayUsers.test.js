import { render, screen, waitFor } from '@testing-library/react';
import axios from 'axios';
import DisplayUsers from './DisplayUsers';

jest.mock('axios', () => {
  const m = { get: jest.fn() };
  return { create: jest.fn(() => m), get: m.get };
});

test('renders users from api', async () => {
  axios.get.mockResolvedValue({ data: [{ userId: 1, username: 'test', course: 'c', purchaseDate: '2024' }] });
  render(<DisplayUsers />);
  await waitFor(() => expect(screen.getByText('test')).toBeInTheDocument());
});
