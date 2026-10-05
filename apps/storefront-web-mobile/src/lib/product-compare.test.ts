import { describe, it, expect, vi } from 'vitest';
import { generateProductComparison } from '@/lib/llm-service';

// Mock the LLM call to make tests fast and reliable
vi.mock('@/lib/llm-service', () => {
    return {
        generateProductComparison: vi.fn(),
    };
});

describe('Product Comparison Logic', () => {
    it('should format comparison points correctly', async () => {
        const mockResponse = {
            comparisonPoints: [
                { feature: 'Battery', item1Value: '30h', item2Value: '24h', verdict: 'Sony wins' }
            ],
            summary: 'Sony has better battery.',
            recommendation: 'Buy Sony for battery life.'
        };

        vi.mocked(generateProductComparison).mockResolvedValue(mockResponse);

        const p1 = { name: 'Sony', price: 100, description: '...', features: [] };
        const p2 = { name: 'Bose', price: 100, description: '...', features: [] };

        const result = await generateProductComparison(p1, p2);

        expect(result.comparisonPoints).toHaveLength(1);
        expect(result.comparisonPoints[0].feature).toBe('Battery');
        expect(result.summary).toContain('Sony');
    });
});
